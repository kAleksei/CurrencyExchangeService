using Hangfire;
using Microsoft.AspNetCore.Builder;

namespace CurrencyExchange.Web.ServicesConfigurations
{
    internal static class EndpointsConfiguration
    {
        public static void UseCustomEndpoints(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapControllers();
                endpoints.MapHangfireDashboard();

            });
        }
    }
}