using Microsoft.EntityFrameworkCore;
using ProductApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApp.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiContext _context;

        public ProductRepository(ApiContext context)
        {
            _context = context;
        }

        public Task<int> CreateAsync(Product product)
        {
            _context.Products.Add(product);
            return _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(string id)
        {
            var existingProduct = await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
            _context.Remove(existingProduct);
            return await _context.SaveChangesAsync();
        }

        public Task<Product> GetAsync(string id)
        {
            return _context.Products.SingleOrDefaultAsync(p => p.Id == id);
        }

        public Task<List<Product>> GetListAsync()
        {
            return _context.Products.ToListAsync();
        }

        public async Task<int> UpdateAsync(Product product)
        {
            var existingProduct = await _context.Products.SingleOrDefaultAsync(p => p.Id == product.Id);

            if (existingProduct == null) return 0;

            existingProduct.Description = product.Description;
            existingProduct.Brand = product.Brand;
            existingProduct.Model = product.Model;

            _context.Products.Update(existingProduct);
            return await _context.SaveChangesAsync();
        }
    }
}
