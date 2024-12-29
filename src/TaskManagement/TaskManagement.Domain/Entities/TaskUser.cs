using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Entities
{
    public class TaskUser : BaseEntity
    {
        public int TaskId { get; set; }
        public TaskInfo Task { get; set; }
        public int UserId { get; set; }
        public UserInfo User { get; set; }
    }

}
