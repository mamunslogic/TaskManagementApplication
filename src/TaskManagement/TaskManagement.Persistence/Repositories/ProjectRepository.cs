using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Persistence.Data;

namespace TaskManagement.Persistence.Repositories
{
    public class ProjectRepository(ApplicationDbContext dbContext) : IProjectRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<int> CreateAsync(Project project)
        {
            await _dbContext.Projects.AddAsync(project);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _dbContext.Projects.AsNoTracking().ToListAsync();
        }

        public async Task<Project> GetById(int projectId)
        {
            return await _dbContext.Projects.AsNoTracking().SingleOrDefaultAsync(s => s.Id == projectId);
        }
    }
}
