using TaskManagementSystem.Domain.Enums;

namespace TaskManagementSystem.Application.Features.ProjectTasks.DTOs;

public class TaskResponse
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public ProjectTaskStatus Status { get; set; }

    public TaskPriority Priority { get; set; }

    public DateTime? DueDate { get; set; }

    public int ProjectId { get; set; }
}