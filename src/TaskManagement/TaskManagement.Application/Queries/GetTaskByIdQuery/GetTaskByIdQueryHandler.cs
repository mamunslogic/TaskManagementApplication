using MediatR;
using TaskManagement.Domain.DTOs;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Queries.GetTaskByIdQuery
{
    public class GetTaskByIdQueryHandler(ITaskRepository taskRepository) : IRequestHandler<GetTaskByIdQuery, TaskDto>
    {
        private readonly ITaskRepository _taskRepository = taskRepository;

        public async Task<TaskDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetById(request.TaskId);
            return new TaskDto
            {
                Name = task.Name,
                Description = task.Description
            };
        }
    }
}
