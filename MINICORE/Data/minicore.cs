using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MINICORE.Models;

namespace MINICORE.Data
{
    public class minicore : DbContext
    {
        public minicore(DbContextOptions<minicore> options)
            : base(options)
        {
        }

        public DbSet<ComitionRule> Reglas { get; set; } = default!;
        public DbSet<Sale> Ventas { get; set; } = default!;
        public DbSet<Seller> Vendedores { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ComitionRule>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.MinimumAmount)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();
                entity.Property(e => e.CommissionPercentage)
                    .HasColumnType("decimal(5,2)")
                    .IsRequired();
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired();
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();
                entity.Property(e => e.SaleDate)
                    .IsRequired();
                entity.HasOne(v => v.Seller)
                    .WithMany(vd => vd.Sales)
                    .HasForeignKey(v => v.SellerId) 
                    .OnDelete(DeleteBehavior.Cascade);
            });

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seller>().HasData(
                new Seller { Id = 1, Name = "Juan Pérez" },
                new Seller { Id = 2, Name = "María González" },
                new Seller { Id = 3, Name = "Carlos Ramírez" }
            );

            modelBuilder.Entity<ComitionRule>().HasData(
                new ComitionRule { Id = 1, MinimumAmount = 0, CommissionPercentage = 5 },
                new ComitionRule { Id = 2, MinimumAmount = 10000, CommissionPercentage = 7.5m },
                new ComitionRule { Id = 3, MinimumAmount = 50000, CommissionPercentage = 10 },
                new ComitionRule { Id = 4, MinimumAmount = 100000, CommissionPercentage = 12.5m }
            );

            modelBuilder.Entity<Sale>().HasData(
                new Sale { Id = 1, SellerId = 1, Amount = 15000, SaleDate = new DateTime(2025, 10, 11) },
                new Sale { Id = 2, SellerId = 1, Amount = 25000, SaleDate = new DateTime(2025, 10, 13) },
                new Sale { Id = 3, SellerId = 2, Amount = 80000, SaleDate = new DateTime(2025, 10, 16) },
                new Sale { Id = 4, SellerId = 2, Amount = 45000, SaleDate = new DateTime(2025, 10, 18) },
                new Sale { Id = 5, SellerId = 3, Amount = 120000, SaleDate = new DateTime(2025, 10, 20) }
            );
        }
    }
}