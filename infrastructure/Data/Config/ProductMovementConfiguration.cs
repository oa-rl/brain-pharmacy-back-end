using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Data.Config
{
    public class ProductMovementConfiguration : IEntityTypeConfiguration<ProductMovementEntity>
    {
        public void Configure(EntityTypeBuilder<ProductMovementEntity> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.ProductCombinationId).IsRequired();
            builder.Property(p => p.ExpirationDate);
            builder.Property(p => p.Quantity).IsRequired();
            builder.Property(p => p.OperationTypeId).IsRequired();
        }
    }
}
