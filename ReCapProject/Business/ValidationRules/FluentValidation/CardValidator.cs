using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CardValidator : AbstractValidator<Card>
    {
        public CardValidator()
        {
            RuleFor(c => c.CardFullName).NotEmpty();
            RuleFor(c => c.CardNumber).NotEmpty();
            RuleFor(c => c.Cvc).NotEmpty();
            RuleFor(c => c.ExpirationMonth).NotEmpty();
            RuleFor(c => c.ExpirationYear).NotEmpty();
            RuleFor(c => c.ExpirationMonth).LessThanOrEqualTo("12");
            RuleFor(c => c.ExpirationMonth).GreaterThan("0");
            RuleFor(c => c.ExpirationYear).GreaterThan(DateTime.Now.Year.ToString());

        }
    }
}
