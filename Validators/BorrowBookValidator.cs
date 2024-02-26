using FluentValidation;
using LibraryProject.Core.DTO;

namespace LibraryProject.Validators;

public class BorrowBookValidator : AbstractValidator<BorrowBookDTO>
{
    public BorrowBookValidator()
    {
        RuleFor(b => b.BorrowDate)
            .NotEmpty()
                .WithMessage("Borrow Date must not be null or empty");


        RuleFor(i => i.UserId)
            .NotEmpty()
                    .WithMessage("User Id must not be null or empty")
            .GreaterThan(0)
                .WithMessage("Book id is invalid");

        RuleFor(i => i.BookId)
         .NotEmpty()
                 .WithMessage("Book Id must not be null or empty")
         .GreaterThan(0)
            .WithMessage("Book id is invalid");


    }   
}
