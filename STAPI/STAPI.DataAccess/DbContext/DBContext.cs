using Microsoft.EntityFrameworkCore;
using STAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.DataAccess.DBContext
{
    public class STAPIDbContext : DbContext
    {
        // MyDbContext.cs

        public DbSet<Offer> Offers { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.uses("YourConnectionString");
        //    }
        //}
        public STAPIDbContext(DbContextOptions<STAPIDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Job -> Sale (1-N)
            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Job)
                .WithMany(j => j.Sales)
                .HasForeignKey(s => s.JobId)
                .OnDelete(DeleteBehavior.SetNull);

            // Stock -> Sale (1-N)
            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Stock)
                .WithMany(st => st.Sales)
                .HasForeignKey(s => s.StockId)
                .OnDelete(DeleteBehavior.Restrict);

            // Customer -> Sale (1-N)
            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);

            // Stock -> StockMovement (1-N)
            modelBuilder.Entity<StockMovement>()
                .HasOne(sm => sm.Stock)
                .WithMany(s => s.StockMovements)
                .HasForeignKey(sm => sm.StockId)
                .OnDelete(DeleteBehavior.Cascade);

            // Transaction -> Sale (N-1)
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Sale)
                .WithMany()
                .HasForeignKey(t => t.SaleId)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);

        }
    }
}
