using MediatR;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Queries.ProjectQuery
{
    public class ProjectQueryHandler(IProjectRepository projectRepository) : IRequestHandler<ProjectQuery, List<Project>>
    {
        private readonly IProjectRepository _projectRepository = projectRepository;

        public async Task<List<Project>> Handle(ProjectQuery request, CancellationToken cancellationToken)
        {
            return await _projectRepository.GetAllAsync();
        }
    }
}
