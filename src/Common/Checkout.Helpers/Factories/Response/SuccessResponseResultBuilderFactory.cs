using Checkout.Helpers.Factories.Response.Builders;
using Checkout.Services.Factories.Response;
using System.Collections.Generic;
using System.Net;

namespace Checkout.Helpers.Factories.Response
{
    /// <summary>
    /// The success response result builder factory.
    /// </summary>
    public class SuccessResponseResultBuilderFactory : ResponseResultBuilderFactory
    {
        private readonly Dictionary<HttpStatusCode, IResponseBuilder> _factories;

        /// <summary>
        /// Initializes a new instance of the <see cref="SuccessResponseResultBuilderFactory"/> class.
        /// </summary>
        public SuccessResponseResultBuilderFactory()
        {
            _factories = new Dictionary<HttpStatusCode, IResponseBuilder>
            {
                { HttpStatusCode.Created, new CreatedResponseBuilder() },
                { HttpStatusCode.OK, new OkObjectResponseBuilder() }
            };
        }

        /// <inheritdoc/>
        public override IResponseBuilder Create(HttpStatusCode statusCode) => _factories[statusCode];
    }
}
