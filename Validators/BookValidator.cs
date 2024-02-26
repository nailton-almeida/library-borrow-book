using FluentValidation;
using LibraryProject.Core.Model;

namespace LibraryProject.Validators;

public class BookValidator : AbstractValidator<Book>
{
    public BookValidator()
    {
        RuleFor(t => t.Title)
            .NotEmpty()
                .WithMessage("Title must not be null or empty")
            .MaximumLength(50)
                .WithMessage("Title must have up to 50 characters");

        RuleFor(a => a.Author)
           .NotEmpty()
               .WithMessage("Author must not be null or empty")
           .MinimumLength(5)
           .MaximumLength(50)
               .WithMessage("Author name must have between 5 to 50 characters");

        RuleFor(y => y.YearPublication)
            .NotEmpty()
                .WithMessage("Year Publication must not be null or empty")
            .LessThan(DateTime.Now.Year);

        RuleFor(i => i.ISBN)
            .NotEmpty()
                .WithMessage("Year Publication must not be null or empty")
             .Length(10)
                .WithMessage("ISBN invalid");
    }
}
