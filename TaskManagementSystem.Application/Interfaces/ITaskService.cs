using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Features.ProjectTasks.DTOs;

namespace TaskManagementSystem.Application.Interfaces
{
    public interface ITaskService
    {
        Task<TaskResponse> CreateAsync(CreateTaskRequest request);

        Task<IEnumerable<TaskResponse>> GetAllAsync(int projectId);

        Task<TaskResponse> GetByIdAsync(int id);

        Task<TaskResponse> UpdateAsync(int id, UpdateTaskRequest request);

        Task DeleteAsync(int id);
    }
}
