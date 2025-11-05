using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel.DataAnnotations;

namespace CotizadorAutoMAPFRESeguros.Server.Filter
{
    public class RequiredPropertiesSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            var requiredProps = context.Type
                .GetProperties()
                .Where(prop => Attribute.IsDefined(prop, typeof(RequiredAttribute)))
                .Select(prop => prop.Name);

            foreach (var propName in requiredProps)
            {
                if (!schema.Required.Contains(propName))
                {
                    schema.Required.Add(propName);
                }
            }
        }
    }
}
