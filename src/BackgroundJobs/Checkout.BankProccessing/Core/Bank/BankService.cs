using Checkout.Application.Payments.Commands.CreatePayment;
using Checkout.Application.Payments.Commands.UpdatePayment;
using Checkout.BankProccessing.Core.Bank.Contract;
using Checkout.Enums;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.BankProccessing.Core.Bank
{
    /// <summary>
    /// Bank service.
    /// </summary>
    public class BankService : IBankService
    {
        private readonly IPublishEndpoint _endpoint;
        public BankService(IPublishEndpoint endpoint)
        {
            _endpoint = endpoint;
        }

        ///<inheritdoc/>
        public async Task ProccessPaymentAsync(PaymentCreated paymentCreated)
        {
            var updatePaymentEvent = new UpdatePaymentEvent
            {
                RequestId = paymentCreated.RequestId,
                BankRequestId = Guid.NewGuid().ToString(),
                State = DateTimeOffset.UtcNow.ToUnixTimeSeconds() % 2 == 0 ? TransactionStateEnum.Payed : TransactionStateEnum.Failed
            };

            await _endpoint.Publish<UpdatePaymentEvent>(updatePaymentEvent);
        }
    }
}
