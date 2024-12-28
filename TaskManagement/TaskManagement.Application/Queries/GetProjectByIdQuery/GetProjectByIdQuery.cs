using MediatR;
using TaskManagement.Domain.DTOs;

namespace TaskManagement.Application.Queries.GetProjectByIdQuery
{
    public class GetProjectByIdQuery : IRequest<ProjectDto>
    {
        public int ProjectId { get; set; }
    }
}
