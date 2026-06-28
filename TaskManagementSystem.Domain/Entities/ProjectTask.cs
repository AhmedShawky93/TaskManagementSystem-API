using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Common;
using TaskManagementSystem.Domain.Enums;

namespace TaskManagementSystem.Domain.Entities
{
    public class ProjectTask : BaseEntity
    {
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public ProjectTaskStatus Status { get; set; } = ProjectTaskStatus.Todo;

        public DateTime? DueDate { get; set; }

        public TaskPriority Priority { get; set; } = TaskPriority.Medium;

        public int ProjectId { get; set; }

        public Project Project { get; set; } = null!;
    }
}
