using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.DTOs
{
    public class ProjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime? EstimatedStartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public decimal EstimatedManHours { get; set; } = 0.0m;

        public ProjectStatus Status { get; set; } = ProjectStatus.InPlanning;
        public ProjectState State { get; set; } = ProjectState.NotStartedYet;
    }
}
