using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Data.Config
{
    public class SaleInvoiceDetailsConfiguration : IEntityTypeConfiguration<SaleInvoiceDetailsEntity>
    {
        public void Configure(EntityTypeBuilder<SaleInvoiceDetailsEntity> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.SaleInvoiceId).IsRequired();
            builder.Property(p => p.ProductCombinationId).IsRequired();
            builder.Property(p => p.Amount).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.PriceWithOutTax).IsRequired();
            builder.Property(p => p.Tax).IsRequired();
        }
    }
}
