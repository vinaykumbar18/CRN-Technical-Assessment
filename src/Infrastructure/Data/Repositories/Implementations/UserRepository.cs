using Microsoft.EntityFrameworkCore;
using Product_Management.src.Infrastructure.Data.Repositories.Interface;
using Product_Management.src.Domain.Entities;

namespace Product_Management.src.Infrastructure.Data.Repositories.Implementations
{
        public class UserRepository : IUserRepository
        {
            private readonly ApplicationDbContext _context;

            public UserRepository(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<User?> GetByUserNameAsync(string userName)
            {
                return await _context.Users
                    .FirstOrDefaultAsync(x => x.UserName == userName);
            }

            public async Task AddAsync(User user)
            {
                await _context.Users.AddAsync(user);
            }

            public async Task SaveChangesAsync()
            {
                await _context.SaveChangesAsync();
            }
        }
    }

