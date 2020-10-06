using CurrencyExchange.DataAccess.Context;
using CurrencyExchange.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyExchange.Web.ServicesConfigurations
{
    internal static class DataAccessConfiguration
    {
        public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CurrencyExchangeContext>(
                (serviceProvider, options) =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Transient,
                ServiceLifetime.Scoped
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>(ServiceProvider =>
            {
                CurrencyExchangeContext context = ServiceProvider.GetRequiredService<CurrencyExchangeContext>();
                var unitOfWork = new UnitOfWork(context);
                unitOfWork.RegisterRepositoryWithAssembly(typeof(IGenericRepository<,>).Assembly);
                return unitOfWork;
            });
        }
    }
}