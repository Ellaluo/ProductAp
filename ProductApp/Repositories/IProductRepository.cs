using ProductApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApp.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetListAsync();
        Task<Product> GetAsync(string id);
        Task<int >CreateAsync(Product product);
        Task<int> UpdateAsync(Product product);
        Task<int> DeleteAsync(string id);
    }
}
