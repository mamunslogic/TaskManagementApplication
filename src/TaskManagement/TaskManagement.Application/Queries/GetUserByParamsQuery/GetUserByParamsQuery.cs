using MediatR;
using TaskManagement.Domain.DTOs;

namespace TaskManagement.Application.Queries.GetUserByParamsQuery
{
    public class GetUserByParamsQuery : IRequest<UserDto>
    {
        public int UserId { get; set; }
        public string Email { get; set; }
    }
}
