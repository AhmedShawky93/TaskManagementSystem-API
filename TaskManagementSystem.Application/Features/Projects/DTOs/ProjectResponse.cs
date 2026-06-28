namespace TaskManagementSystem.Application.Features.Projects.DTOs;

public class ProjectResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }
}