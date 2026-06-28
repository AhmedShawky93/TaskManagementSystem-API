using FluentValidation;
using TaskManagementSystem.Application.Features.Projects.DTOs;

namespace TaskManagementSystem.Application.Validators;

public class UpdateProjectRequestValidator
    : AbstractValidator<UpdateProjectRequest>
{
    public UpdateProjectRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(500);
    }
}