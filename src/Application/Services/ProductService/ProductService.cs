using Microsoft.EntityFrameworkCore;
using Product_Management.src.Application.Interfaces;
using Product_Management.src.Application.DTOs.Product;
using Product_Management.src.Domain.Entities;
using Product_Management.src.Infrastructure.Data;

namespace Product_Management.src.Application.Services.ProductService
{
        public class ProductService : IProductService
        {
            private readonly ApplicationDbContext _context;

            public ProductService(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
            {
                return await _context.Products
                    .Select(p => new ProductResponseDto
                    {
                        Id = p.Id,
                        ProductName = p.ProductName,
                        CreatedBy = p.CreatedBy,
                        CreatedOn = p.CreatedOn
                    })
                    .ToListAsync();
            }

            public async Task<ProductResponseDto?> GetByIdAsync(int id)
            {
                return await _context.Products
                    .Where(p => p.Id == id)
                    .Select(p => new ProductResponseDto
                    {
                        Id = p.Id,
                        ProductName = p.ProductName,
                        CreatedBy = p.CreatedBy,
                        CreatedOn = p.CreatedOn
                    })
                    .FirstOrDefaultAsync();
            }

            public async Task CreateAsync(ProductCreateDto dto)
            {
                var product = new Product
                {
                    ProductName = dto.ProductName,
                    CreatedBy = "Admin",
                    CreatedOn = DateTime.UtcNow
                };

                _context.Products.Add(product);

                await _context.SaveChangesAsync();
            }

            public async Task UpdateAsync(int id,
                ProductUpdateDto dto)
            {
                var product =
                    await _context.Products.FindAsync(id);

                if (product == null)
                    return;

                product.ProductName = dto.ProductName;
                product.ModifiedBy = "Admin";
                product.ModifiedOn = DateTime.UtcNow;

                await _context.SaveChangesAsync();
            }

            public async Task DeleteAsync(int id)
            {
                var product =
                    await _context.Products.FindAsync(id);

                if (product == null)
                    return;

                _context.Products.Remove(product);

                await _context.SaveChangesAsync();
            }
        }
    
}
