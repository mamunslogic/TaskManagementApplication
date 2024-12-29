using MediatR;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Commands.UserRegistration
{
    public class UserRegistrationCommand : IRequest<int>
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.TeamMember;
    }
}
