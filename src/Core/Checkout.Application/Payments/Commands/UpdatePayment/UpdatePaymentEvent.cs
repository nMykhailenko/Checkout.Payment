using Checkout.Enums;

namespace Checkout.Application.Payments.Commands.UpdatePayment
{
    /// <summary>
    /// Update payment event.
    /// </summary>
    public class UpdatePaymentEvent
    {
        /// <summary>
        /// Gets or sets a payment Gateway request id.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets or sets a bank request id.
        /// </summary>
        public string BankRequestId { get; set; }

        /// <summary>
        /// Gets or sets a transaction state.
        /// </summary>
        public TransactionStateEnum State { get; set; }
    }
}
