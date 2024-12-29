using MediatR;

namespace TaskManagement.Application.Commands.CreateProject
{
    public class CreateProjectCommand:IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? EstimatedStartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public decimal EstimatedManHours { get; set; } = 0.0m;
    }
}
