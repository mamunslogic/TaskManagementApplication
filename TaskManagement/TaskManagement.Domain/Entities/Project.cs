using System.ComponentModel.DataAnnotations;
using TaskManagement.Domain.Validations;

namespace TaskManagement.Domain.Entities
{
    public class Project : BaseEntity
    {
        [Required(ErrorMessage = "Project name is required.")]
        [StringLength(100, ErrorMessage = "Project name cannot exceed 100 characters.")]
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

        public ProjectStatus Status { get; set; } = ProjectStatus.InPlanning;
        public ProjectState State { get; set; } = ProjectState.NotStartedYet;

        // Relationships
        public ICollection<TaskInfo> Tasks { get; set; } // One-to-Many with Task
    }

}
