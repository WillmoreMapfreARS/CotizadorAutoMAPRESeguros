
using CotizadorAutoMAPFRESeguros.Server.Filter;
using CotizadorAutoMAPFRESeguros.Server.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

namespace CotizadorAutoMAPFRESeguros.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            //// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            //builder.Services.AddOpenApi();
            builder.Services.AddTransient(x => new CotizacionToken(builder.Configuration));

            // Agregar servicios de Swagger
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Web API Salesforce",
                    Version = "v1"
                });

                // Definir esquema de seguridad
                options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    Description = "API Key requerida en el encabezado 'X-API-KEY'",
                    Type = SecuritySchemeType.ApiKey,
                    Name = "X-API-KEY",
                    In = ParameterLocation.Header,
                    Scheme = "ApiKeyScheme"
                });
                options.SchemaFilter<RequiredPropertiesSchemaFilter>();
                // Requerir el esquema en todos los endpoints
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                },
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
            });

            // 1. Definir la política CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.WithOrigins("https://localhost:7286") // <- tu frontend
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                    policy.WithOrigins("http://10.160.225.39:9095") // <- tu frontend
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.MapOpenApi();
            }
            // 2. Usar la política CORS definida
            app.UseCors("AllowFrontend");
            app.UseSwagger();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
