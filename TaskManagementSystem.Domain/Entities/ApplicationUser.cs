using Microsoft.AspNetCore.Identity;

namespace TaskManagementSystem.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public ICollection<Project> Projects { get; set; } = new List<Project>();
}