using Checkout.Enums;

namespace Checkout.Application.Payments.Commands.CreatePayment
{
    /// <summary>
    /// Class describes payment created event.
    /// </summary>
    public class PaymentCreated
    {
        /// <summary>
        /// Gets or sets an id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets a request id.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets or sets a state.
        /// </summary>
        public TransactionStateEnum State { get; set; }
    }
}
