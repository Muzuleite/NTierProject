
using FluentValidation;
using Project.Validation.Models.RequestModels.AppUserProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Validation.FluentValidators.AppUserProfiles
{
    public class CreateAppUserProfileRequestModelValidator: AbstractValidator<CreateAppUserProfileRequestModel>
    {
        public CreateAppUserProfileRequestModelValidator()
        {
            RuleFor(x => x.AppUserId)
                .GreaterThan(0).WithMessage("Kullanıcı Id geçerli olmalıdır.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad zorunludur.")
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyad zorunludur.")
                .MaximumLength(50);
        }
    }

}
