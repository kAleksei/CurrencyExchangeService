using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace CurrencyExchange.Web.ServicesConfigurations
{
    internal static class LoggerConfiguration
    {
        public static void UseLogger(this IApplicationBuilder app, IWebHostEnvironment hostingEnvironment, ILoggerFactory loggerFactory)
        {
                loggerFactory.AddLog4Net($"{hostingEnvironment.ContentRootPath}/log4net.config");
        }
    }
}
