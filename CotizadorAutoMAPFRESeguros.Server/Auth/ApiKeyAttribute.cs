namespace CotizadorAutoMAPFRESeguros.Server.Auth
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Configuration;
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiKeyHeaderName = "x-api-key";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var configuration = context.HttpContext.RequestServices.GetService<IConfiguration>();
            var expectedApiKey = configuration!.GetValue<string>("APIKEY");

            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var providedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "API Key is missing"
                };
                return;
            }

            if (!expectedApiKey.Equals(providedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Invalid API Key"
                };
                return;
            }

            await next();
        }
    }

}
