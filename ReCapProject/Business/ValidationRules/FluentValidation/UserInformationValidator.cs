using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserInformationValidator : AbstractValidator<UserInformation>
    {
        public UserInformationValidator()
        {
            RuleFor(u=> u.FirstName).NotEmpty();
            RuleFor(u=> u.LastName).NotEmpty();
            RuleFor(u => u.FindeksPoint).GreaterThanOrEqualTo("0");
            RuleFor(u => u.FindeksPoint).LessThanOrEqualTo("1900");
        }
    }
}
