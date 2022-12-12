using FluentValidation;
using ReadingList.Service.DataTransferObjects;

namespace ReadingList.API.Validators
{
    public class BookValidator : AbstractValidator<BookDto>
    {
        public BookValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(25).WithMessage("Maximum Length: 25 characters");
            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Author is required")
                .MaximumLength(25).WithMessage("Maximum Length: 25 characters");
            RuleFor(x => x.Order)
                .GreaterThan(0).WithMessage("Order must be greater than 0");
            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Category is required");
                

        }
    }
}
