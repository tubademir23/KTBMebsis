using KTB.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTB.Data.Configurations
{
    class EserConfiguration:IEntityTypeConfiguration<Eser>
    {
        public void Configure(EntityTypeBuilder<Eser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.EserAdi).IsRequired().HasMaxLength(40);
            builder.ToTable("eser");
        }
    }
}
