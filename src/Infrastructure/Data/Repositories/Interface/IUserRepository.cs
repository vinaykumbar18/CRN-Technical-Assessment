using Product_Management.src.Domain.Entities;

namespace Product_Management.src.Infrastructure.Data.Repositories.Interface
{
        public interface IUserRepository
        {
            Task<User?> GetByUserNameAsync(string userName);

            Task AddAsync(User user);

            Task SaveChangesAsync();
        }
    }

