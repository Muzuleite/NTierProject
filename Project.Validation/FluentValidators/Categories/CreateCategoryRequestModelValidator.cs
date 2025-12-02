using FluentValidation;
using Project.Validation.Models.RequestModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Validation.FluentValidators.Categories
{
    public class CreateCategoryRequestModelValidator
        : AbstractValidator<CreateCategoryRequestModel>
    {
        public CreateCategoryRequestModelValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Description)
                .MaximumLength(200);
        }
    }
}
