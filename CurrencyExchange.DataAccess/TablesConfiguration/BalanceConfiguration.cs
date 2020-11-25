using CurrencyExchange.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurrencyExchange.DataAccess.TablesConfiguration
{
    internal sealed class BalanceConfiguration : IEntityTypeConfiguration<CurrencyBalance>
    {
        public void Configure(EntityTypeBuilder<CurrencyBalance> builder)
        {
            builder.ToTable("Balances");

            builder.HasOne(b => b.Currency).WithOne(c => c.CurrencyBalance);
            builder.Property(b => b.Balance).HasColumnType("decimal");
        }
    }
}