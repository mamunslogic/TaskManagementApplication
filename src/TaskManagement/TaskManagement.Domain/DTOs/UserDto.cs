using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.DTOs
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public IList<TaskInfo> AssignedTasks { get; set; }
    }
}
