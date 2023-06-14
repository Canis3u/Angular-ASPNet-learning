using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using week3.Models;
#nullable disable

namespace week3.Models
{
    public partial class WeatherforecastContext : DbContext
    {
        public WeatherforecastContext()
        {
        }

        public WeatherforecastContext(DbContextOptions<WeatherforecastContext> options)
            : base(options)
        {
        }

        public virtual DbSet<WeatherCast> WeatherCasts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<WeatherCast>(entity =>
            {
                entity.ToTable("WeatherCast");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasColumnName("Is_Deleted");

                entity.Property(e => e.Summary)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
