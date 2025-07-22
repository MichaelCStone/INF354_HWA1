using Microsoft.EntityFrameworkCore;
using u21497682_HW01_API.Data;
using u21497682_HW01_API.Models;

namespace u21497682_HW01_API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> UpdateProduct(Product product)
        {
            var existingProduct = await _context.Products.FindAsync(product.Product_ID);
            if (existingProduct == null)
            {
                return null;
            }

            existingProduct.Product_Name = product.Product_Name;
            existingProduct.Product_Description = product.Product_Description;
            existingProduct.Product_Price = product.Product_Price;

            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null)
            {
                return false;
            }

            _context.Products.Remove(existingProduct);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
