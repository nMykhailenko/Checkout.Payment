using Checkout.Helpers.Factories.Response.Builders;
using System.Net;

namespace Checkout.Helpers.Factories.Response
{
    /// <summary>
    /// The builder factory for the response result generation.
    /// </summary>
    public abstract class ResponseResultBuilderFactory
    {
        /// <summary>
        /// Creates the response depending on status code.
        /// </summary>
        /// <param name="statusCode">The status code to define the response type.</param>
        /// <returns>An <see cref="IResponseBuilder"/> response.</returns>
        public abstract IResponseBuilder Create(HttpStatusCode statusCode);
    }
}
