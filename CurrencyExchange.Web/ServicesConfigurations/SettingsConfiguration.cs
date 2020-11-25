using CurrencyExchange.Domains.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyExchange.Web.ServicesConfigurations
{
    internal static class SettingsConfiguration
    {
        public static void AddSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();

            services.Configure<ConnectionStringSettings>(configuration.GetSection("ConnectionStrings"));
            services.Configure<ForeignExchangeRatesAPISettings>(configuration.GetSection("ExchangeRatesAPI"));
            services.Configure<CurrencyBalanceSettings>(configuration.GetSection("CurrencyBalance"));


        }
    }
}