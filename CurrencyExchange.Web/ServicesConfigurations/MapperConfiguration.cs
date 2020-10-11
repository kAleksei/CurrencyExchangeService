using System;
using System.Linq;
using AutoMapper;
using CurrencyExchange.Domains.MappingProfiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyExchange.Web.ServicesConfigurations
{
    internal static class MapperConfiguration
    {
        public static void AddMapper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(CurrencyProfile).Assembly);
        }
    }
}
