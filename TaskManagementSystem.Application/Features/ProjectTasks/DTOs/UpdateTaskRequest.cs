using TaskManagementSystem.Domain.Enums;

namespace TaskManagementSystem.Application.Features.ProjectTasks.DTOs;

public class UpdateTaskRequest
{
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public ProjectTaskStatus Status { get; set; }

    public TaskPriority Priority { get; set; }

    public DateTime? DueDate { get; set; }
}