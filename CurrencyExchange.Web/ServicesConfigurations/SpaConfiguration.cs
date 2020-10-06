using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace CurrencyExchange.Web.ServicesConfigurations
{
    internal static class SpaConfiguration
    {
        public static void AddSpa(this IServiceCollection services, IConfiguration configuration)
        {
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(spaConfiguration =>
            {
                spaConfiguration.RootPath = "ClientApp/build";
            });
        }

        public static void UseSpa(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
