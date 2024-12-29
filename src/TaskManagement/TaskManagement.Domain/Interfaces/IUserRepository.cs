using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(UserInfo user);
        Task<UserInfo> GetByParams(int userId, string email);
        Task<List<UserInfo>> GetAllAsync();
    }
}
