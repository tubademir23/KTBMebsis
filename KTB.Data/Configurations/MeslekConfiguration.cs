using KTB.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KTB.Data.Configurations
{
    class MeslekConfiguration:IEntityTypeConfiguration<Meslek>
    {
        public void Configure(EntityTypeBuilder<Meslek> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            //builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Adi).IsRequired().HasMaxLength(40);
            // builder.Property(m => m.Id).UseIdentityAlwaysColumn().HasIdentityOptions(startValue: 1);
            builder.ToTable("meslek");
        }
    }
}
