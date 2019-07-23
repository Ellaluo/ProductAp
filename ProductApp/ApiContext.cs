using Microsoft.EntityFrameworkCore;
using ProductApp.Models;

namespace ProductApp
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

    }
}
