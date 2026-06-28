using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Interfaces.Security;

public interface IJwtTokenGenerator
{
    Task<string> GenerateTokenAsync(ApplicationUser user);
}