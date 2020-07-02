using Checkout.Enums;
using System;

namespace Checkout.Domain.Entitities
{
    /// <summary>
    /// Class describes payment transaction.
    /// </summary>
    public class Transaction
    {
        public Transaction()
        {
            CreatedUTCDateTime = DateTime.UtcNow;
            RequestId = Guid.NewGuid().ToString();
            State = TransactionStateEnum.Pendig;
        }

        /// <summary>
        /// Gets or sets an id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets a request id.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets or sets a bank request id.
        /// </summary>
        public string BankRequestId { get; set; }

        /// <summary>
        /// Gets or sets an amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets a state.
        /// </summary>
        public TransactionStateEnum State { get; set; }

        /// <summary>
        /// Gets or sets created date.
        /// </summary>
        public DateTime CreatedUTCDateTime { get; set; }

        /// <summary>
        /// Gets or sets an user id.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets a payment id.
        /// </summary>
        public long PaymentId { get; set; }

        /// <summary>
        /// Gets or sets a payment.
        /// </summary>
        public Payment Payment { get; set; }
    }
}
