using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Data.Config
{
    public class SaleInvoiceConfiguration : IEntityTypeConfiguration<SaleInvoiceEntity>
    {
        public void Configure(EntityTypeBuilder<SaleInvoiceEntity> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Authorization).IsRequired();
            builder.Property(p => p.Date).IsRequired();
            builder.Property(p => p.CustomerId).IsRequired();
        }
    }
}
