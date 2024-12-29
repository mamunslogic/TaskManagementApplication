namespace TaskManagement.Domain.Entities
{
    // Enum: Admin, ProjectManager, TeamMember
    public enum UserRole
    {
        Admin,
        ProjectManager,
        TeamMember
    }

    // Enum: Pending, InProgress, Completed
    public enum TaskStatus
    {
        Pending, InProgress, Completed, OnHold, Cancelled
    }

    public enum ProjectStatus
    {
        InPlanning, InProgress, Completed, OnHold, Cancelled
    }

    public enum ProjectState
    {
        NotStartedYet, // Initial state where no action is taken
        InAnalysis,    // Requirements gathering or feasibility analysis
        InDevelopment, // Active development phase
        InQA,          // Testing and quality assurance phase
        InStaging,     // Staging environment for final testing and validation
        InProduction   // Deployed and operational 
    }
}
