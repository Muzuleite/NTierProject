using FluentValidation;
using Project.Validation.Models.RequestModels.AppUsers;

namespace Project.Validation.FluentValidators.AppUsers
{
    public class UpdateAppUserRequestModelValidator
        : AbstractValidator<UpdateAppUserRequestModel>
    {
        public UpdateAppUserRequestModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.UserName)
                .NotEmpty()
                .MinimumLength(3);
        }
    }
}
