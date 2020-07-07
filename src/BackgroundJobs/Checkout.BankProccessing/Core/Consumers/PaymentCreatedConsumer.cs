using Checkout.Application.Payments.Commands.CreatePayment;
using Checkout.BankProccessing.Core.Bank.Contract;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Checkout.BankProccessing.Core.Consumers
{
    /// <summary>
    /// Payment created consumer.
    /// </summary>
    public class PaymentCreatedConsumer : IConsumer<PaymentCreated>
    {
        private readonly IBankService _bankService;
        private readonly ILogger<PaymentCreatedConsumer> _logger;
        public PaymentCreatedConsumer(IBankService bankService, ILogger<PaymentCreatedConsumer> logger)
        {
            _bankService = bankService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<PaymentCreated> context)
        {
            try
            {
                _logger.LogInformation("Payment created handle {Message}", context.Message);

                await _bankService.ProccessPaymentAsync(context.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError("PaymentCreatedConsumerError", ex);
            }
        }
    }
}
