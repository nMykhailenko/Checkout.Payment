using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Domain.ValueObjects
{
    /// <summary>
    /// Class describes credit-card information.
    /// </summary>
    public class CardInformation : ValueObject
    {
        public CardInformation()
        {

        }

        public CardInformation(string cardNumber, string cardHolder)
        {
            CardNumber = cardNumber;
            CardHolder = cardHolder;
        }

        /// <summary>
        /// Gets or sets a card number.
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets a card holder.
        /// </summary>
        public string CardHolder { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return CardNumber;
            yield return CardHolder;
        }
    }
}
