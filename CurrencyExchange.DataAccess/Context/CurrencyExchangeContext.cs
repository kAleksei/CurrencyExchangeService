using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.DataAccess.Context
{
    public class CurrencyExchangeContext: DbContext
    {
        public CurrencyExchangeContext(DbContextOptions<CurrencyExchangeContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CurrencyExchangeContext).Assembly);
        }
    }
}
