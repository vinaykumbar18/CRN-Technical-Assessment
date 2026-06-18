using Product_Management.src.Domain.Entities;

namespace Product_Management.src.Infrastructure.Data.Repositories.Interface
{
        public interface IProductRepository
        {
            Task<IEnumerable<Product>> GetAllAsync();

            Task<Product?> GetByIdAsync(int id);

            Task AddAsync(Product product);

            void Update(Product product);

            void Delete(Product product);

            Task SaveChangesAsync();
        }
    }

