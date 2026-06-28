using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.ProjectTasks.DTOs;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Domain.Enums;
using TaskManagementSystem.Infrastructure.Persistence;


namespace TaskManagementSystem.Infrastructure.Services;

public class TaskService : ITaskService
{
    private readonly ApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;

    public TaskService(
        ApplicationDbContext context,
        ICurrentUserService currentUserService)
    {
        _context = context;
        _currentUserService = currentUserService;
    }

    public async Task<TaskResponse> CreateAsync(CreateTaskRequest request)
    {
        var userId = _currentUserService.UserId;

        if (string.IsNullOrWhiteSpace(userId))
            throw new UnauthorizedException("User is not authenticated.");

        var project = await _context.Projects
            .FirstOrDefaultAsync(x => x.Id == request.ProjectId && x.UserId == userId);

        if (project == null)
            throw new NotFoundException("Project not found.");

        var task = new ProjectTask
        {
            Title = request.Title,
            Description = request.Description,
            DueDate = request.DueDate,
            ProjectId = request.ProjectId,
            Status = ProjectTaskStatus.Todo,
            Priority = TaskPriority.Medium
        };

        _context.ProjectTasks.Add(task);

        await _context.SaveChangesAsync();

        return new TaskResponse
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            Status = task.Status,
            Priority = task.Priority,
            DueDate = task.DueDate,
            ProjectId = task.ProjectId
        };
    }
    public async Task<IEnumerable<TaskResponse>> GetAllAsync(int projectId)
    {
        var userId = _currentUserService.UserId;

        var project = await _context.Projects.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == projectId && x.UserId == userId);

        if (project == null)
            throw new NotFoundException("Project not found.");

        return await _context.ProjectTasks.AsNoTracking()
            .Where(x => x.ProjectId == projectId)
            .Select(x => new TaskResponse
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Status = x.Status,
                Priority = x.Priority,
                DueDate = x.DueDate,
                ProjectId = x.ProjectId
            })
            .ToListAsync();
    }

    public async Task<TaskResponse> GetByIdAsync(int id)
    {
        var userId = _currentUserService.UserId;

        var task = await _context.ProjectTasks.AsNoTracking()
            .Include(x => x.Project)
            .FirstOrDefaultAsync(x =>
                x.Id == id &&
                x.Project.UserId == userId);

        if (task == null)
            throw new NotFoundException("Task not found.");

        return new TaskResponse
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            Status = task.Status,
            Priority = task.Priority,
            DueDate = task.DueDate,
            ProjectId = task.ProjectId
        };
    }

    public async Task<TaskResponse> UpdateAsync(int id, UpdateTaskRequest request)
    {
        var userId = _currentUserService.UserId;

        var task = await _context.ProjectTasks
            .Include(x => x.Project)
            .FirstOrDefaultAsync(x =>
                x.Id == id &&
                x.Project.UserId == userId);

        if (task == null)
            throw new NotFoundException("Task not found.");

        task.Title = request.Title;
        task.Description = request.Description;
        task.DueDate = request.DueDate;

        task.Status = request.Status;
        task.Priority = request.Priority;

        await _context.SaveChangesAsync();

        return new TaskResponse
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            Status = task.Status,
            Priority = task.Priority,
            DueDate = task.DueDate,
            ProjectId = task.ProjectId
        };
    }

    public async Task DeleteAsync(int id)
    {
        var userId = _currentUserService.UserId;

        var task = await _context.ProjectTasks
            .Include(x => x.Project)
            .FirstOrDefaultAsync(x =>
                x.Id == id &&
                x.Project.UserId == userId);

        if (task == null)
            throw new NotFoundException("Task not found.");

        _context.ProjectTasks.Remove(task);

        await _context.SaveChangesAsync();
    }
}