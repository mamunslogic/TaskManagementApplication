using MediatR;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Queries.UserQuery
{
    public class UserQuery : IRequest<List<UserInfo>>
    {
        public int UserId { get; set; }
    }
}
