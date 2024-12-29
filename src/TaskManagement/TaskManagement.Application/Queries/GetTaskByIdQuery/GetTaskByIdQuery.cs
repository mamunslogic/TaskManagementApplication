using MediatR;
using TaskManagement.Domain.DTOs;

namespace TaskManagement.Application.Queries.GetTaskByIdQuery
{
    public class GetTaskByIdQuery : IRequest<TaskDto>
    {
        public int TaskId { get; set; }
    }
}
