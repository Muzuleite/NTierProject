using FluentValidation;
using Project.Validation.Models.RequestModels.Categories;

namespace Project.Validation.FluentValidators.Categories
{
    public class UpdateCategoryRequestModelValidator
        : AbstractValidator<UpdateCategoryRequestModel>
    {
        public UpdateCategoryRequestModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.CategoryName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Description)
                .MaximumLength(200);
        }
    }
}
