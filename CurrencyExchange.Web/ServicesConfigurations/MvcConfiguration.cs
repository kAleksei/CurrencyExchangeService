using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyExchange.Web.ServicesConfigurations
{
    internal static class MvcConfiguration
    {
        public static void AddMvc(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc();
        }
    }
}