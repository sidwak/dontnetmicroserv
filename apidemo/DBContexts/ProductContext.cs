using apidemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace apidemo.DBContexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "iphone 15",
                    Description = "Electronic Items",
                    Price = 80000,

                },
                new Product
                {
                    Id = 2,
                    Name = "Macbook",
                    Description = "Laptops",
                    Price = 50000,
                },
                new Product
                {
                    Id = 3,
                    Name = "S23",
                    Description = "Mobile",
                    Price = 75000,
                }
            );
            modelBuilder.Entity<Order>().HasData(
                new Order 
                { 
                    Id = 1,
                    FirstName = "Siddeshwar",
                    LastName = "Wakkalkar",
                    Email = "sidwak@gmail.com",
                    Phone = "1234567890",
                    Address = "Ruia Matunga",
                    Zip = "400001",
                    State = "Maharashtra",
                    Country = "India",
                    TotalQuantity = 1,
                    TotalPrice = 75000,
                    Items = "mackbook14,",
                    PaymentMethod = "DebitCard",
                    CardNumber = "1234123412341234",
                }
            );
        }

    }
}