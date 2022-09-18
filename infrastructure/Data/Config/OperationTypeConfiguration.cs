using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Data.Config
{
    public class OperationTypeConfiguration : IEntityTypeConfiguration<OperationTypeEntity>
    {
        public void Configure(EntityTypeBuilder<OperationTypeEntity> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Sign).IsRequired().HasMaxLength(2);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(150);
        }
    }
}
