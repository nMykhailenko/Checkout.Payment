using Checkout.Extensions;
using System.Collections.Generic;

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
            CardNumber = cardNumber.EncryptSha512();
            MaskedCardNumber = cardNumber.Mask(2, cardNumber.Length - 4);
            CardHolder = cardHolder;
        }

        /// <summary>
        /// Gets or sets a card number.
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets masked card number.
        /// </summary>
        public string MaskedCardNumber { get; set; }

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
