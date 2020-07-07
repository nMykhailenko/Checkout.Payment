using Checkout.Persistence;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Checkout.Application.Payments.Commands.UpdatePayment
{
    /// <summary>
    /// Update paymet event consumer.
    /// </summary>
    public class UpdatePaymentEventConsumer : IConsumer<UpdatePaymentEvent>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<UpdatePaymentEventConsumer> _logger;
        public UpdatePaymentEventConsumer(IServiceProvider serviceProvider, ILogger<UpdatePaymentEventConsumer> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdatePaymentEvent> context)
        {
            try
            {
                _logger.LogInformation("Update payment event handle {Message}", context.Message);

                var dbContext = _serviceProvider.GetRequiredService<CheckoutDbContext>();
                var transaction = await dbContext.Transactions
                    .FirstOrDefaultAsync(x => x.RequestId == context.Message.RequestId);

                if (transaction == null) _logger.LogError($"Payment with transaction request id: {context.Message.RequestId} not found.");

                transaction.State = context.Message.State;
                transaction.BankRequestId = context.Message.BankRequestId;

                dbContext.Transactions.Update(transaction);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("UpdatePaymentEventConsumer", ex);
            }
        }
    }
}
