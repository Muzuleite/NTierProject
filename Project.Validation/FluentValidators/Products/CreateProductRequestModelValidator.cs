using FluentValidation;
using Project.Validation.Models.RequestModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Validation.FluentValidators.Products
{
    public class CreateProductRequestModelValidator
        : AbstractValidator<CreateProductRequestModel>
    {
        public CreateProductRequestModelValidator()
        {
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
