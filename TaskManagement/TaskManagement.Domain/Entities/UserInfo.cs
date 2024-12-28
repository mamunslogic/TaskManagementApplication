using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Entities
{
    public class UserInfo : BaseEntity
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Project name is required.")]
        [StringLength(100, ErrorMessage = "Project name cannot exceed 100 characters.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public required string PasswordHash { get; set; }

        public UserRole Role { get; set; }

        // Relationships
        public ICollection<TaskUser> AssignedTasks { get; set; } // Many-to-Many with Task
    }

}
