using Checkout.Application.Payments.Commands.UpdatePayment;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Checkout.PaymentGateway.Workers
{
    /// <summary>
    /// Payment gateway worker.
    /// </summary>
    public class GatewayWorker : BackgroundService
    {
        private readonly ILogger<GatewayWorker> _logger;
        private readonly IBusControl _busControl;
        private readonly IServiceProvider _serviceProvider;

        public GatewayWorker(IServiceProvider serviceProvider, ILogger<GatewayWorker> logger, IBusControl busControl)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _busControl = busControl;
        }

        /// <summary>
        /// Execute async.
        /// </summary>
        /// <param name="stoppingToken">Cancellation token.</param>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _logger.LogInformation("Payment Gateway Worker started");


                var hostReceiveEndpointHandler = _busControl.ConnectReceiveEndpoint("update-payments", x =>
                {
                    x.Consumer<UpdatePaymentEventConsumer>(_serviceProvider);
                });

                await hostReceiveEndpointHandler.Ready;
            }
            catch (Exception ex)
            {
                _logger.LogError("Payment Gateway Worker error", ex);
            }
        }
    }
}
