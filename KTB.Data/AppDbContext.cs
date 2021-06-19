using KTB.Core.Entities;
using KTB.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTB.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MeslekConfiguration());
           modelBuilder.ApplyConfiguration(new UyeConfiguration());
            modelBuilder.ApplyConfiguration(new EserConfiguration());
            

            /*modelBuilder.Entity<Eser>(entity =>
            {
                entity.Property(e => e.eseradi)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.Uye)
                    .WithMany(p => p.Eserler)
                    .HasForeignKey(d => d.uyeid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_uye_eser");
            });
            modelBuilder.Entity<Uye>(entity =>
            {
                entity.Property(u => u.Adi)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });
            */
        }

public virtual DbSet<Uye> Uye { get; set; }
        public virtual DbSet<Eser> Eser { get; set; }
        public virtual DbSet<Meslek> Meslek { get; set; }
    }
}
