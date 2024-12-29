using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public int Serial { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public required string Content { get; set; }

        // Polymorphic Relationship
        public required int ReferenceId { get; set; } // ID of the related entity (Task or Project)
        public required string ReferenceType { get; set; } // "Task" or "Project"
    }
}
