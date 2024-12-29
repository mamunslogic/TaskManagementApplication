using MediatR;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Queries.UserQuery
{
    internal class UserQueryHandler(IUserRepository userRepository) : IRequestHandler<UserQuery, List<UserInfo>>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public Task<List<UserInfo>> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            return _userRepository.GetAllAsync();
        }
    }
}
