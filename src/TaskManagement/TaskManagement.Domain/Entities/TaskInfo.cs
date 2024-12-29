using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManagement.Domain.Validations;

namespace TaskManagement.Domain.Entities
{
    public class TaskInfo : BaseEntity
    {
        [Required(ErrorMessage = "Task name is required.")]
        [StringLength(100, ErrorMessage = "Task name cannot exceed 100 characters.")]
        public required string Name { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "Due date is required.")]
        [DataType(DataType.DateTime)]
        [NotWeekend]
        public DateTime DueDate { get; set; }

        public DateTime? EstimatedStartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }

        [Required(ErrorMessage = "ManHours are required.")]
        [Range(0.1, 1000, ErrorMessage = "ManHours must be between 0.1 and 1000.")]
        public decimal EstimatedManHours { get; set; } = 0.0m;

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal UsedManHours { get; set; } = 0.0m;

        public TaskStatus Status { get; set; } = TaskStatus.Pending;

        // Relationships
        [ForeignKey("Project")]
        public int ProjectId { get; set; } // Foreign Key to Project
        public Project Project { get; set; } // Navigation Property

        public int? ParentTaskId { get; set; } // Self-referencing for Subtasks
        public TaskInfo ParentTask { get; set; }    // Navigation Property
        public ICollection<TaskInfo> SubTasks { get; set; } // One-to-Many for Subtasks

        public ICollection<TaskUser> AssignedUsers { get; set; } // Many-to-Many with User
        public ICollection<Comment> Comments { get; set; }   // One-to-Many with Comment
        public ICollection<Attachment> Attachments { get; set; } // One-to-Many with Attachment
    }

}
