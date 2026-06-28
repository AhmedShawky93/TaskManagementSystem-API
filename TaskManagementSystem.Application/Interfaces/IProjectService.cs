using TaskManagementSystem.Application.Features.Projects.DTOs;

namespace TaskManagementSystem.Application.Interfaces;

public interface IProjectService
{
    Task<ProjectResponse> CreateAsync(CreateProjectRequest request);
    Task<IEnumerable<ProjectResponse>> GetAllAsync();

    Task<ProjectResponse> GetByIdAsync(int id);

    Task<ProjectResponse> UpdateAsync(int id, UpdateProjectRequest request);

    Task DeleteAsync(int id);
}