using FluentValidation;
using Project.Validation.Models.RequestModels.OrderDetails;

namespace Project.Validation.FluentValidators.OrderDetails
{
    public class UpdateOrderDetailRequestModelValidator
        : AbstractValidator<UpdateOrderDetailRequestModel>
    {
        public UpdateOrderDetailRequestModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.OrderId)
                .GreaterThan(0);

            RuleFor(x => x.ProductId)
                .GreaterThan(0);
        }
    }
}
