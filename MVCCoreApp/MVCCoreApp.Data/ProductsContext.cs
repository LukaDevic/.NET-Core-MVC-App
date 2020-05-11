using Microsoft.EntityFrameworkCore;
using MVCCoreApp.Data.Models;

namespace MVCCoreApp.Data
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options)
        : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
