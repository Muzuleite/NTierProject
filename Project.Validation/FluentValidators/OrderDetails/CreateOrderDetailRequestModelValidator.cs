using FluentValidation;
using Project.Validation.Models.RequestModels.OrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Validation.FluentValidators.OrderDetails
{
    public class CreateOrderDetailRequestModelValidator
        : AbstractValidator<CreateOrderDetailRequestModel>
    {
        public CreateOrderDetailRequestModelValidator()
        {
            RuleFor(x => x.OrderId)
                .GreaterThan(0);

            RuleFor(x => x.ProductId)
                .GreaterThan(0);
        }
    }
}
