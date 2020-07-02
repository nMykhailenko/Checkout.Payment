using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Application.Payments.Query.GetPaymentDetail
{
    /// <summary>
    /// Get payment detail query.
    /// </summary>
    public class GetPaymentDetailQuery : IRequest<PaymentDetailResponseModel>
    {
        /// <summary>
        /// Payment Gateway payment identifier.
        /// </summary>
        public string RequestId { get; set; }
    }
}
