using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Persistence.Data;

namespace TaskManagement.Persistence.Repositories
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task AddAsync(UserInfo user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserInfo>> GetAllAsync()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<UserInfo> GetByParams(int userId, string email)
        {
            if (userId > 0)
            {
                return await _context.Users.AsNoTracking().SingleOrDefaultAsync(s => s.Id == userId);
            }
            if (email != null)
            {
                return await _context.Users.AsNoTracking().SingleOrDefaultAsync(s => s.Email == email);
            }
            return null;
        }
    }
}
