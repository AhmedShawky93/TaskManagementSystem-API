namespace TaskManagementSystem.Application.Features.Projects.DTOs;

public class UpdateProjectRequest
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}