using FluentValidation;
using ReadingList.API.Models;

namespace ReadingList.API.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryViewModel>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(25).WithMessage("Maximum Length: 25 characters");

        }

    }
}
