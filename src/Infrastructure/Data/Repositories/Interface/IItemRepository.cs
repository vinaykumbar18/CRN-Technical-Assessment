using Product_Management.src.Domain.Entities;

namespace Product_Management.src.Infrastructure.Data.Repositories.Interface
{
        public interface IItemRepository
        {
            Task<IEnumerable<Item>> GetAllAsync();

            Task<Item?> GetByIdAsync(int id);

            Task AddAsync(Item item);

            void Update(Item item);

            void Delete(Item item);

            Task SaveChangesAsync();
        }
    }

