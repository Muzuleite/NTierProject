using FluentValidation;
using Project.Validation.Models.RequestModels.Orders;

namespace Project.Validation.FluentValidators.Orders
{
    public class UpdateOrderRequestModelValidator
        : AbstractValidator<UpdateOrderRequestModel>
    {
        public UpdateOrderRequestModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.ShippingAddress)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.AppUserId)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
