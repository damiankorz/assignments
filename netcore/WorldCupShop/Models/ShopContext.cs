using Microsoft.EntityFrameworkCore;

namespace WorldCupShop.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) {}
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Product> Products {get; set;}
        public DbSet<Order> Orders {get; set;}
    }
}