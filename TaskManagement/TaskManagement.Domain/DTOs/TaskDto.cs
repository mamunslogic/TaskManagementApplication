using System;
namespace TaskManagement.Domain.DTOs
{
    public class TaskDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? EstimatedStartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public decimal EstimatedManHours { get; set; } = 0.0m;
        public int ProjectId { get; set; }
    }
}
