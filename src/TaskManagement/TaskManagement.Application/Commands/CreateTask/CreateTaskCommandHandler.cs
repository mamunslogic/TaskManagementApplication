using MediatR;
using Microsoft.VisualBasic;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Commands.CreateTask
{
    public class CreateTaskCommandHandler(ITaskRepository taskRepository) : IRequestHandler<CreateTaskCommand, int>
    {
        private readonly ITaskRepository _taskRepository = taskRepository;

        public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new TaskInfo
            {
                Name = request.Name,
                Description = request.Description,
                ProjectId = request.ProjectId,
                DueDate = DateTime.UtcNow.AddDays(10),
                EstimatedStartDate = DateTime.UtcNow.AddDays(2),
                EstimatedEndDate = DateTime.UtcNow.AddDays(10),
                EstimatedManHours = 200,

                CreatedAt = DateTime.UtcNow,
                CreatedBy = 1
            };

            await _taskRepository.AddAsync(task);
            return task.Id;
        }
    }
}
