using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;
using System.Linq;

namespace Shop.DB
{
    public sealed class AppDbContent : DbContext
    {
        public AppDbContent(DbContextOptions<AppDbContent> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Veg> Veg {get; set;}
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopCartItem> ShopCartItems { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
    }
}