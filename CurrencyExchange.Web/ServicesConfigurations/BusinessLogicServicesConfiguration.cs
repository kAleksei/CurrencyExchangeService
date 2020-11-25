using AutoMapper;
using CurrencyExchange.BusinessLogic.Decorators;
using CurrencyExchange.BusinessLogic.Interfaces;
using CurrencyExchange.BusinessLogic.Services;
using CurrencyExchange.DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyExchange.Web.ServicesConfigurations
{
    internal static class BusinessLogicServicesConfiguration
    {
        public static void AddBusinessLogicServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICityService, CityService>();

            services.AddTransient<CurrencyService>();

            services.AddTransient<ICurrencyService>(provider => new CurrencyServiceWithArchiving(provider.GetRequiredService<IUnitOfWork>(),
                provider.GetRequiredService<IMapper>(), provider.GetRequiredService<CurrencyService>()));

            services.AddTransient<IForeignExchangeRatesAPIService, ForeignExchangeRatesAPIService>();
            services.AddTransient<IBalanceService, BalanceService>();
        }
    }
}