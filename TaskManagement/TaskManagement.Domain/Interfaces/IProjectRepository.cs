using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<int>CreateAsync(Project project);
        Task<Project> GetById(int projectId);
    }
}
