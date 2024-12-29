using MediatR;
using TaskManagement.Domain.DTOs;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Queries.GetUserByParamsQuery
{
    public class GetUserByParamsQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByParamsQuery, UserDto>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<UserDto> Handle(GetUserByParamsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByParams(request.UserId, request.Email);
            if (user == null) { return null; }
            return new UserDto
            {
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}
