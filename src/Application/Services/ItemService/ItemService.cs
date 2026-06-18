using Microsoft.EntityFrameworkCore;
using Product_Management.src.Application.Interfaces;
using Product_Management.src.Application.DTOs.Item;
using Product_Management.src.Domain.Entities;
using Product_Management.src.Infrastructure.Data;

namespace Product_Management.src.Application.Services.ItemService
{
    
        public class ItemService : IItemService
        {
            private readonly ApplicationDbContext _context;

            public ItemService(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<ItemResponseDto>> GetAllAsync()
            {
                return await _context.Items
                    .Include(i => i.Product)
                    .Select(i => new ItemResponseDto
                    {
                        Id = i.Id,
                        ProductId = i.ProductId,
                        ProductName = i.Product.ProductName,
                        Quantity = i.Quantity
                    })
                    .ToListAsync();
            }

            public async Task<ItemResponseDto?> GetByIdAsync(int id)
            {
                return await _context.Items
                    .Include(i => i.Product)
                    .Where(i => i.Id == id)
                    .Select(i => new ItemResponseDto
                    {
                        Id = i.Id,
                        ProductId = i.ProductId,
                        ProductName = i.Product.ProductName,
                        Quantity = i.Quantity
                    })
                    .FirstOrDefaultAsync();
            }

            public async Task CreateAsync(ItemCreateDto dto)
            {
                var item = new Item
                {
                    ProductId = dto.ProductId,
                    Quantity = dto.Quantity
                };

                _context.Items.Add(item);

                await _context.SaveChangesAsync();
            }

            public async Task UpdateAsync(int id,
                ItemUpdateDto dto)
            {
                var item =
                    await _context.Items.FindAsync(id);

                if (item == null)
                    return;

                item.Quantity = dto.Quantity;

                await _context.SaveChangesAsync();
            }

            public async Task DeleteAsync(int id)
            {
                var item =
                    await _context.Items.FindAsync(id);

                if (item == null)
                    return;

                _context.Items.Remove(item);

                await _context.SaveChangesAsync();
            }
        }
    }

