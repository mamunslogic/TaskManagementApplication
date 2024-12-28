using MediatR;
using TaskManagement.Domain.DTOs;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Queries.GetProjectByIdQuery
{
    public class GetProjectByIdQueryHandler(IProjectRepository projectRepository) : IRequestHandler<GetProjectByIdQuery, ProjectDto>
    {
        IProjectRepository _projectRepository = projectRepository;
        public async Task<ProjectDto> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetById(request.ProjectId);
            return new ProjectDto
            {
                Name = project.Name,
                Description = project.Description,
                DueDate = project.DueDate,

                EstimatedStartDate = project.EstimatedStartDate,
                EstimatedEndDate = project.EstimatedEndDate,
                EstimatedManHours = project.EstimatedManHours,

                Status = project.Status,
                State = project.State
            };
        }
    }
}
