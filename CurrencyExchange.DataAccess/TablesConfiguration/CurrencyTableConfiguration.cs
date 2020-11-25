using Microsoft.EntityFrameworkCore;
using CurrencyExchange.Domains.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurrencyExchange.DataAccess.TablesConfiguration
{
    internal sealed class CurrencyTableConfiguration: IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("Currencies");
            builder.HasOne(c => c.City);
            builder.HasOne(c => c.CurrencyBalance).WithOne(b => b.Currency);

        }
    }
}