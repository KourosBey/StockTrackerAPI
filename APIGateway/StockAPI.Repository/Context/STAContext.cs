using Microsoft.EntityFrameworkCore;
using StockAPI.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Repository.Context
{
    public class STAContext : DbContext
    {
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockTransaction> StockTransactions { get; set; }

        public STAContext(DbContextOptions<STAContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>(e =>
            {
                e.HasKey(e => e.Id);

            });
            modelBuilder.Entity<StockTransaction>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasOne(e => e.Stock)
                            .WithMany(u => u.StockTransactions)
                            .HasForeignKey(u => u.StockId);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
