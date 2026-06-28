namespace TaskManagementSystem.Application.Features.ProjectTasks.DTOs;

public class CreateTaskRequest
{
    public int ProjectId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? DueDate { get; set; }
}