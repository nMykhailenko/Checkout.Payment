using FluentValidation;

namespace Checkout.Application.Payments.Query.GetPaymentDetail
{
    /// <summary>
    /// Get payment detail query validator.
    /// </summary>
    public class GetPaymentDetailQueryValidator : AbstractValidator<GetPaymentDetailQuery>
    {
        public GetPaymentDetailQueryValidator()
        {
            RuleFor(x => x.RequestId).NotNull().NotEmpty();
        }
    }
}
