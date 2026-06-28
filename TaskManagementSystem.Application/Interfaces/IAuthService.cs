using TaskManagementSystem.Application.Features.Authentication.DTOs;

namespace TaskManagementSystem.Application.Interfaces;

public interface IAuthService
{
    Task<AuthResponse> RegisterAsync(RegisterRequest request);

    Task<AuthResponse> LoginAsync(LoginRequest request);
}