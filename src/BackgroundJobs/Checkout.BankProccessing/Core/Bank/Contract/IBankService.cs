using Checkout.Application.Payments.Commands.CreatePayment;
using System.Threading.Tasks;

namespace Checkout.BankProccessing.Core.Bank.Contract
{
    /// <summary>
    /// Bank service.
    /// </summary>
    public interface IBankService
    {
        /// <summary>
        /// Proccess payment created event.
        /// </summary>
        /// <param name="paymentCreated">Payment created model.</param>
        Task ProccessPaymentAsync(PaymentCreated paymentCreated);
    }
}
