using MediatR;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Queries.TaskQuery
{
    public class TaskQueryHandler(ITaskRepository taskRepository) : IRequestHandler<TaskQuery, List<TaskInfo>>
    {
        private readonly ITaskRepository _taskRepository = taskRepository;

        public Task<List<TaskInfo>> Handle(TaskQuery request, CancellationToken cancellationToken)
        {
            return _taskRepository.GetAllAsync();
        }
    }
}
