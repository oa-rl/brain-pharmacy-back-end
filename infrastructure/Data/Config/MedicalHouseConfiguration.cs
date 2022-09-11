using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Data.Config
{
	public class MedicalHouseConfiguration: IEntityTypeConfiguration<MedicalHouseEntity>
    {
		
        public void Configure(EntityTypeBuilder<MedicalHouseEntity> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
        }
    }
}

