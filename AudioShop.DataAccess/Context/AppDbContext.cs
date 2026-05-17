using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.DataAccess;
using AudioShop.Domains.Entities.Cart;
using AudioShop.Domains.Entities.Order;
using AudioShop.Domains.Entities.Product;
using AudioShop.Domains.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace AudioShop.DataAccess.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
            }
        }


        public DbSet<ProductData> ProductDatas { get; set; }
        public DbSet<UserData> UserDatas { get; set; }
        public DbSet<OrderData> OrderDatas { get; set; }
        public DbSet<OrderItemData> OrderItemDatas { get; set; }
        public DbSet<CartData> CartDatas { get; set; }
        public DbSet<CartItemData> CartItemDatas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CartData>()
                .HasOne(c => c.User)
                .WithOne(u => u.Cart)
                .HasForeignKey<CartData>(c => c.UserId);

            modelBuilder.Entity<OrderData>()
               .HasOne(o => o.User)
               .WithMany(u => u.Orders)
               .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<OrderItemData>()
               .HasOne(oi => oi.Order)
               .WithMany(o => o.Items)
               .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<CartItemData>()
               .HasOne(ci => ci.Cart)
               .WithMany(c => c.Items)
               .HasForeignKey(ci => ci.CartId);

            modelBuilder.Entity<CartItemData>()
               .HasOne(ci => ci.Product)
               .WithMany()
               .HasForeignKey(ci => ci.ProductId);

            modelBuilder.Entity<OrderItemData>()
               .HasOne(oi => oi.Product)
               .WithMany()
               .HasForeignKey(oi => oi.ProductId);



            modelBuilder.Entity<CartData>()
                .Property(c => c.TotalPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<CartItemData>()
                .Property(ci => ci.UnitPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<CartItemData>()
                .Property(ci => ci.TotalPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderData>()
                .Property(o => o.TotalPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderItemData>()
                .Property(oi => oi.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ProductData>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);
        }
    }
}