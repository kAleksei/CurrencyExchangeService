using System;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyExchange.Web.ServicesConfigurations
{
    internal static class MapperConfiguration
    {
        public static void AddMapper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.Contains("CurrencyExchange.Domains")));
        }
    }
}
