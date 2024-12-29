using MediatR;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Commands.UserRegistration
{
    internal class UserRegistrationCommandHandler (IUserRepository userRepository) : IRequestHandler<UserRegistrationCommand, int>
    {
        private readonly IUserRepository _userRepository=userRepository;

        public async Task<int> Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
        {
            var user = new UserInfo
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = request.Password,

                CreatedAt = DateTime.UtcNow,
                CreatedBy = 1
            };

            await _userRepository.AddAsync(user);
            return user.Id;
        }
    }
}
