using AudioShop.Domains.Entitiies.Order;
using AudioShop.Domains.Entitiies.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AudioShop.DataAccess.Context
{
    public class OrderContext : DbContext
    {

        public DbSet<OrderData> Orders { get; set; }
        public DbSet<OrderItemData> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderData>()
                .HasMany(i => i.Items)
                .WithOne(o => o.Order)
                .HasForeignKey(o => o.OrderId);
        }
    }
}
