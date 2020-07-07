namespace Checkout.Models.Options
{
    /// <summary>
    /// Rabbit MQ options.
    /// </summary>
    public class RabbitMqOptions
    {
        /// <summary>
        /// Gets or sets hostname.
        /// </summary>
        public string Hostname { get; set; }

        /// <summary>
        /// Gets or sets username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a virtual host.
        /// </summary>
        public string VirtualHost { get; set; }
    }
}
