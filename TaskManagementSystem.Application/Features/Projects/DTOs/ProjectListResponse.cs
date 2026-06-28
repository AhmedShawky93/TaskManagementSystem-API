namespace TaskManagementSystem.Application.Features.Projects.DTOs;

public class ProjectListResponse
{
    public IEnumerable<ProjectResponse> Projects { get; set; } = [];

    public int TotalCount { get; set; }
}