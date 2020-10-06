using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
namespace CurrencyExchange.Web.ServicesConfigurations
{
    internal static class SwaggerConfiguration
    {

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo {Title = "Currency Exchange API", Version = "V1.0"});
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

        }

        public static void UseSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger(opt => {});

            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint(url: "v1.0/swagger.json", name: "API V1.0");
            });
        }

    }
}