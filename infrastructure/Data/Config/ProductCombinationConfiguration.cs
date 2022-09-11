using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Data.Config
{
	public class ProductCombinationConfiguration: IEntityTypeConfiguration<ProductCombinationEntity>
    {
        public void Configure(EntityTypeBuilder<ProductCombinationEntity> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.ProductId).IsRequired();
            builder.Property(p => p.SizeId).IsRequired();
            builder.Property(p => p.AmountSize).IsRequired();
            builder.Property(p => p.MedicalHouseId).IsRequired();
            builder.Property(p => p.SaleForId).IsRequired();
            builder.Property(p => p.AmountSale).IsRequired();
            builder.Property(p => p.Price).IsRequired();
        }
    }
}

