using FluentValidation;
using LibraryProject.Core.Model;

namespace LibraryProject.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(e => e.Email)
            .NotEmpty()
                .WithMessage("Email must not be null or empty")
            .EmailAddress()
                .WithMessage("Email address invalid")
            .MaximumLength(50)
                .WithMessage("Email must have up to 50 characters");

        RuleFor(n => n.Name)
            .NotEmpty()
                    .WithMessage("Name must not be null or empty")
             .MaximumLength(60)
                    .WithMessage("Name must have up to 60 characters");
    }   
}
