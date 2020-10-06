using CurrencyExchange.BusinessLogic.Interfaces;
using CurrencyExchange.BusinessLogic.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyExchange.Web.ServicesConfigurations
{
    internal static class BusinessLogicServicesConfiguration
    {
        public static void AddBusinessLogicServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<ICityService, CityService>();
        }
    }
}