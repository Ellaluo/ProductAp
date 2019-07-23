using ProductApp.Models;
using ProductApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService (IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetListAsync()
        {
            return await _repository.GetListAsync();
        }

        public Task<Product> GetAsync(string id)
        {
            return _repository.GetAsync(id);
        }

        public async Task<Product> CreateAsync(Product product)
        {
            var result = await _repository.CreateAsync(product);
            if (result == 1) return product;
            return null;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            var result = await _repository.UpdateAsync(product);
            if (result == 1) return product;
            return null;
        }

        public Task<int> DeleteAsync(string id)
        {
            return _repository.DeleteAsync(id);
        }
    }
}
