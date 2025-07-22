using Microsoft.EntityFrameworkCore;
using u21497682_HW01_API.Models;

namespace u21497682_HW01_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product 
                {
                    Product_ID = 1,
                    Product_Name = "Running Shoes",
                    Product_Description = "High-performance running shoes designed with breathable mesh and a cushioned sole for maximum comfort and support. Features a sleek design and durable rubber outsole for traction on various surfaces.", 
                    Product_Price = 89.99
                },
                new Product 
                {
                    Product_ID = 2,
                    Product_Name = "Boots",
                    Product_Description = "Sleek leather boots with elastic side panels for easy wear. Features a comfortable insole and durable rubber outsole, ideal for everyday wear.",
                    Product_Price = 89.00
                },
                new Product
                {
                    Product_ID = 3,
                    Product_Name = "Baseball Cap",
                    Product_Description = "A classic baseball cap with an adjustable strap and embroidered logo. Made of breathable cotton, perfect for casual wear and outdoor activities.",
                    Product_Price = 19.99
                },
                new Product
                {
                    Product_ID = 4,
                    Product_Name = "Maxi Dress",
                    Product_Description = "Flowing, floor-length maxi dress made from lightweight fabric. Features an adjustable strap design and a flattering A-line silhouette.",
                    Product_Price = 59.99
                },
                new Product
                {
                    Product_ID = 5,
                    Product_Name = "Slim Fit Chinos",
                    Product_Description = "A pair of slim-fit chinos made from lightweight cotton with a bit of stretch. Features a clean, modern look suitable for both work and weekend wear.",
                    Product_Price = 44.95
                },
                new Product
                {
                    Product_ID = 6,
                    Product_Name = "Hoodie",
                    Product_Description = "Cozy hoodie with a bold graphic print on the front. Made of soft cotton, perfect for lounging or casual outings.",
                    Product_Price = 49.99
                }
            );
        }
    }
}
