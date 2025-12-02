using FluentValidation;
using Project.Validation.Models.RequestModels.Products;

namespace Project.Validation.FluentValidators.Products
{
    public class UpdateProductRequestModelValidator
       : AbstractValidator<UpdateProductRequestModel>
    {
        public UpdateProductRequestModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.ProductName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0);

            RuleFor(x => x.CategoryId)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
