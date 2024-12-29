using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task AddAsync(TaskInfo task);
        Task<TaskInfo> GetById(int taskId);
        Task<List<TaskInfo>> GetAllAsync();
    }
}
