using FluentValidation;
using Project.Validation.Models.RequestModels.AppUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Validation.FluentValidators.AppUsers
{
    public class CreateAppUserRequestModelValidator
        : AbstractValidator<CreateAppUserRequestModel>
    {
        public CreateAppUserRequestModelValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .MinimumLength(3);

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6);

            
        }
    }
}
