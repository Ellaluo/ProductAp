using ProductApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApp.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetListAsync();
        Task<Product> GetAsync(string id);
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<int> DeleteAsync(string id);

    }
}
