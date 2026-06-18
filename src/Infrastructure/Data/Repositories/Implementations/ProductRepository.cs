using Microsoft.EntityFrameworkCore;
using Product_Management.src.Domain.Entities;
using Product_Management.src.Infrastructure.Data.Repositories.Interface;

namespace Product_Management.src.Infrastructure.Data.Repositories.Implementations
{
        public class ProductRepository : IProductRepository
        {
            private readonly ApplicationDbContext _context;

            public ProductRepository(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Product>> GetAllAsync()
            {
                return await _context.Products.ToListAsync();
            }

            public async Task<Product?> GetByIdAsync(int id)
            {
                return await _context.Products.FindAsync(id);
            }

            public async Task AddAsync(Product product)
            {
                await _context.Products.AddAsync(product);
            }

            public void Update(Product product)
            {
                _context.Products.Update(product);
            }

            public void Delete(Product product)
            {
                _context.Products.Remove(product);
            }

            public async Task SaveChangesAsync()
            {
                await _context.SaveChangesAsync();
            }
        }
    }

