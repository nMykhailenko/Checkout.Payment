using FluentValidation;
using System;

namespace Checkout.Application.Payments.Commands.CreatePayment
{
    /// <summary>
    /// Create payment command validator.
    /// </summary>
    public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentCommandValidator()
        {
            RuleFor(x => x.Amount).Must(x => x > 0);
            RuleFor(x => x.CardHolder).MinimumLength(1);
            RuleFor(x => x.CardNumber).MinimumLength(13).MaximumLength(16);
            RuleFor(x => x.ExpireMonth).GreaterThanOrEqualTo(1).LessThanOrEqualTo(12);
            RuleFor(x => x.ExpireYear).GreaterThanOrEqualTo(DateTime.Now.Year);
            RuleFor(x => x.CVV).Must(x => x.Length == 3);
            RuleFor(x => x.UserId).Must(x => x != default);
        }
    }
}
