using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.DataAccess.Context
{
    public class HangfireDbContext : DbContext
    {
        public HangfireDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}