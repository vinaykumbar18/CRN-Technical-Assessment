using Microsoft.EntityFrameworkCore;
using Product_Management.src.Domain.Entities;
using Product_Management.src.Infrastructure.Data.Repositories.Interface;

namespace Product_Management.src.Infrastructure.Data.Repositories.Implementations
{
        public class ItemRepository : IItemRepository
        {
            private readonly ApplicationDbContext _context;

            public ItemRepository(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Item>> GetAllAsync()
            {
                return await _context.Items
                    .Include(i => i.Product)
                    .ToListAsync();
            }

            public async Task<Item?> GetByIdAsync(int id)
            {
                return await _context.Items
                    .Include(i => i.Product)
                    .FirstOrDefaultAsync(i => i.Id == id);
            }

            public async Task AddAsync(Item item)
            {
                await _context.Items.AddAsync(item);
            }

            public void Update(Item item)
            {
                _context.Items.Update(item);
            }

            public void Delete(Item item)
            {
                _context.Items.Remove(item);
            }

            public async Task SaveChangesAsync()
            {
                await _context.SaveChangesAsync();
            }
        }
    }

