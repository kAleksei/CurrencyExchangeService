using System.Linq;
using CurrencyExchange.BusinessLogic.Interfaces;
using CurrencyExchange.DataAccess.Context;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyExchange.Web.ServicesConfigurations
{
    internal static class HangfireConfiguration
    {
        public static void AddHangfire(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHangfire(x => x.UseSqlServerStorage(configuration.GetConnectionString("HangfireCurrency")));

            services.AddDbContext<HangfireDbContext>(op => op.UseSqlServer(configuration.GetConnectionString("HangfireCurrency")));
        }

        public static void UseHangfire(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseHangfireServer();
            ConfigureHangfire();
        }

        private static void ConfigureHangfire()
        {
            RecurringJob.AddOrUpdate<IForeignExchangeRatesAPIService>(s => s.UpdateAllCurrenciesByCities(), Cron.Daily(20));
        }
    }
}