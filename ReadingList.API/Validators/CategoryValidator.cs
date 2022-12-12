using FluentValidation;
using ReadingList.Service.DataTransferObjects;

namespace ReadingList.API.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryDto>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(25).WithMessage("Maximum Length: 25 characters");

        }

    }
}
