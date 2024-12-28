using MediatR;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Commands.CreateProject
{
    internal class CreateProjectCommandHandler(IProjectRepository projectRepository) : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository _projectRepository = projectRepository;

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project
            {
                Name = request.Name,
                Description = request.Description,
                DueDate = DateTime.UtcNow.AddDays(10),
                EstimatedStartDate = DateTime.UtcNow.AddDays(2),
                EstimatedEndDate = DateTime.UtcNow.AddDays(10),
                EstimatedManHours = 200,

                CreatedAt = DateTime.UtcNow,
                CreatedBy = 1
            };

            await _projectRepository.CreateAsync(project);
            return project.Id;
        }
    }
}
