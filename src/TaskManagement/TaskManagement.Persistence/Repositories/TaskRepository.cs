using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Persistence.Data;

namespace TaskManagement.Persistence.Repositories
{
    public class TaskRepository(ApplicationDbContext context) : ITaskRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task AddAsync(TaskInfo task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TaskInfo>> GetAllAsync()
        {
            return await _context.Tasks.AsNoTracking().ToListAsync();
        }

        public async Task<TaskInfo> GetById(int taskId)
        {
            return await _context.Tasks.AsNoTracking().SingleOrDefaultAsync(s => s.Id == taskId);
        }
    }
}
