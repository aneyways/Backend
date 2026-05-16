using Microsoft.EntityFrameworkCore;
using AudioShop.Domains.Entities.User;
using AudioShop.Domains.Entities.Product;
using AudioShop.Domains.Entities.Order;

namespace AudioShop.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<UserData> Users { get; set; }
        public DbSet<ProductData> Products { get; set; }
        public DbSet<OrderData> Orders { get; set; }
        public DbSet<OrderItemData> OrderItems { get; set; }
        public DbSet<CategoryData> Categories { get; set; }
        public DbSet<ProductDescriptionData> ProductDescriptions { get; set; }
        public DbSet<ProductImgData> ProductImages { get; set; }
    }
}