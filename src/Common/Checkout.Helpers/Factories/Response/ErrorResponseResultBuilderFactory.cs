using Checkout.Helpers.Factories.Response.Builders;
using Checkout.Services.Factories.Response.Builders;
using System.Collections.Generic;
using System.Net;

namespace Checkout.Helpers.Factories.Response
{
    /// <summary>
    /// The error response result builder factory.
    /// </summary>
    public class ErrorResponseResultBuilderFactory : ResponseResultBuilderFactory
    {
        private readonly Dictionary<HttpStatusCode, IResponseBuilder> _factories;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResponseResultBuilderFactory"/> class.
        /// </summary>
        public ErrorResponseResultBuilderFactory()
        {
            _factories = new Dictionary<HttpStatusCode, IResponseBuilder>
            {
                { HttpStatusCode.BadRequest, new BadRequestResponseBuilder() },
                { HttpStatusCode.NotFound, new NotFoundResponseBuilder() },
                { HttpStatusCode.InternalServerError, new ServerErrorResponseBuilder() }
            };
        }

        /// <inheritdoc/>
        public override IResponseBuilder Create(HttpStatusCode statusCode) => _factories[statusCode];
    }
}
