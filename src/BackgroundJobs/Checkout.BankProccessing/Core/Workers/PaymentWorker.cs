using Checkout.BankProccessing.Core.Consumers;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Checkout.BankProccessing.Core.Workers
{
    /// <summary>
    /// Payment worker.
    /// </summary>
    public class PaymentWorker : BackgroundService
    {
        private readonly ILogger<PaymentWorker> _logger;
        private readonly IBusControl _busControl;
        private readonly IServiceProvider _serviceProvider;

        public PaymentWorker(IServiceProvider serviceProvider, ILogger<PaymentWorker> logger, IBusControl busControl)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _busControl = busControl;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _logger.LogInformation("PaymentWorker started");


                var hostReceiveEndpointHandler = _busControl.ConnectReceiveEndpoint("payments", x =>
                {
                    x.Consumer<PaymentCreatedConsumer>(_serviceProvider);
                });

                await hostReceiveEndpointHandler.Ready;
            }
            catch (Exception ex)
            {
                _logger.LogError("PaymentWorker error", ex);
            }
        }
    }
}
