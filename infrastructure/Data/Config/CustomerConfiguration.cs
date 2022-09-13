using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Data.Config
{
    public class CustomerConfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(150);
            builder.Property(p => p.NIT).IsRequired().HasMaxLength(10);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Address).IsRequired().HasMaxLength(350);
            builder.Property(p => p.Phone1).IsRequired().HasMaxLength(10);
            builder.Property(p => p.Phone2).IsRequired().HasMaxLength(10);
        }
    }
}
