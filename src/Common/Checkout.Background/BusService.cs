using MassTransit;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace Checkout.Background
{
    /// <summary>
    /// Bus hosted service.
    /// </summary>
    public class BusService : IHostedService
    {
        private readonly IBusControl _busControl;
        public BusService(IBusControl busControl)
        {
            _busControl = busControl;
        }

        /// <summary>
        /// Start hosted service.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        public Task StartAsync(CancellationToken cancellationToken) => _busControl.StartAsync(cancellationToken);


        /// <summary>
        /// Stop hosted service.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        public Task StopAsync(CancellationToken cancellationToken) => _busControl.StopAsync(cancellationToken);
    }
}
