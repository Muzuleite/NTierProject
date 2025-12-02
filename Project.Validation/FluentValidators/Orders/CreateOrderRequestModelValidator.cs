using FluentValidation;
using Project.Validation.Models.RequestModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Validation.FluentValidators.Orders
{
    public class CreateOrderRequestModelValidator
        : AbstractValidator<CreateOrderRequestModel>
    {
        public CreateOrderRequestModelValidator()
        {
            RuleFor(x => x.ShippingAddress)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.AppUserId)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
