using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCCoreApp.Abstractions;
using MVCCoreApp.Data.Models;

namespace MVCCoreApp.Data.Repositories
{
    public class ProductsRepository : IRepository<Product>
    {
        private readonly ProductsContext _context;

        public ProductsRepository(ProductsContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetAsync(Guid id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            product.Id = Guid.NewGuid();

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            var productFromDb = _context.Products.FirstOrDefault(x => x.Id == product.Id);

            if (productFromDb == null)
            {
                throw new ArgumentNullException(nameof(productFromDb));
            }

            productFromDb.Name = product.Name;
            productFromDb.Description = product.Description;
            productFromDb.Category = product.Category;
            productFromDb.Manufacturer = product.Name;
            productFromDb.Supplier = product.Name;
            productFromDb.Price = product.Price;
            await _context.SaveChangesAsync();
        }

        public Task<Product> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
