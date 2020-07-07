using Checkout.Domain.ValueObjects;

namespace Checkout.Domain.Entitities
{
    /// <summary>
    /// Class describes payment
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Gets or sets an id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets a transaction.
        /// </summary>
        public Transaction Transaction { get; set; }

        /// <summary>
        /// Gets or sets a card information.
        /// </summary>
        public CardInformation CardInformation { get; set; }
    }
}
