namespace TaskManagementSystem.Application.Features.Projects.DTOs;

public class CreateProjectRequest
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}