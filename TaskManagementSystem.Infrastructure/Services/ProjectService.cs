using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.Projects.DTOs;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.Persistence;

namespace TaskManagementSystem.Infrastructure.Services;

public class ProjectService : IProjectService
{
    private readonly ApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;

    public ProjectService(
        ApplicationDbContext context,
        ICurrentUserService currentUserService)
    {
        _context = context;
        _currentUserService = currentUserService;
    }

    public async Task<ProjectResponse> CreateAsync(CreateProjectRequest request)
    {
        var userId = _currentUserService.UserId;

        if (string.IsNullOrEmpty(userId))
            throw new UnauthorizedException("User is not authenticated.");

        var project = new Project
        {
            Name = request.Name,
            Description = request.Description,
            UserId = userId
        };

        _context.Projects.Add(project);

        await _context.SaveChangesAsync();

        return new ProjectResponse
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            CreatedAt = project.CreatedAt
        };
    }

    public async Task<IEnumerable<ProjectResponse>> GetAllAsync()
    {
        var userId = _currentUserService.UserId;

        return await _context.Projects.AsNoTracking()
            .Where(x => x.UserId == userId)
            .Select(x => new ProjectResponse
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedAt = x.CreatedAt
            })
            .ToListAsync();
    }

    public async Task<ProjectResponse> GetByIdAsync(int id)
    {
        var userId = _currentUserService.UserId;

        var project = await _context.Projects.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

        if (project == null)
            throw new NotFoundException("Project not found.");

        return new ProjectResponse
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            CreatedAt = project.CreatedAt
        };
    }

    public async Task<ProjectResponse> UpdateAsync(int id, UpdateProjectRequest request)
    {
        var userId = _currentUserService.UserId;

        var project = await _context.Projects
            .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

        if (project == null)
            throw new NotFoundException("Project not found.");

        project.Name = request.Name;
        project.Description = request.Description;

        await _context.SaveChangesAsync();

        return new ProjectResponse
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            CreatedAt = project.CreatedAt
        };
    }

    public async Task DeleteAsync(int id)
    {
        var userId = _currentUserService.UserId;

        var project = await _context.Projects
            .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

        if (project == null)
            throw new NotFoundException("Project not found.");

        _context.Projects.Remove(project);

        await _context.SaveChangesAsync();
    }
}