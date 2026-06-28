using Microsoft.AspNetCore.Identity;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.Authentication.DTOs;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Application.Interfaces.Security;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Infrastructure.Identity;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
    {
        var user = new ApplicationUser
        {
            UserName = request.UserName,
            Email = request.Email
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            throw new ValidationException(string.Join(", ", result.Errors.Select(x => x.Description)));
        }

        var token = await _jwtTokenGenerator.GenerateTokenAsync(user);

        return new AuthResponse
        {
            Token = token,
            Expiration = DateTime.UtcNow.AddMinutes(60)
        };
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
            throw new UnauthorizedException("Invalid email or password.");

        var result = await _signInManager.CheckPasswordSignInAsync(
            user,
            request.Password,
            false);

        if (!result.Succeeded)
            throw new UnauthorizedException("Invalid email or password.");

        var token = await _jwtTokenGenerator.GenerateTokenAsync(user);

        return new AuthResponse
        {
            Token = token,
            Expiration = DateTime.UtcNow.AddMinutes(60)
        };
    }
}