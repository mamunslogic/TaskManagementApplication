using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Entities
{
    public class Attachment : BaseEntity
    {
        public string? FileName { get; set; }
        public required string FileUrl { get; set; }

        // Polymorphic Relationship
        public required int ReferenceId { get; set; } // ID of the related entity (Task or Project)
        public required string ReferenceType { get; set; } // "Task" or "Project"
    }
}
