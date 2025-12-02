
using FluentValidation;
using Project.Validation.Models.RequestModels.AppUserProfiles;

namespace Project.Validation.FluentValidators.AppUserProfiles
{
    public class UpdateAppUserProfileRequestModelValidator : AbstractValidator<UpdateAppUserProfileRequestModel>
    {
        public UpdateAppUserProfileRequestModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(50);
        }
    }

}
