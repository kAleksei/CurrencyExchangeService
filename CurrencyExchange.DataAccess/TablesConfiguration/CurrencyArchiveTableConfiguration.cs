using CurrencyExchange.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurrencyExchange.DataAccess.TablesConfiguration
{
    internal sealed class CurrencyArchiveTableConfiguration : IEntityTypeConfiguration<CurrencyArchive>
    {
        public void Configure(EntityTypeBuilder<CurrencyArchive> builder)
        {
            builder.ToTable("CurrenciesArchive");
            builder.HasOne(c => c.City);
            builder.HasOne(c => c.CurrencyReference);
            builder.HasOne(c => c.CurrencyReference)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}