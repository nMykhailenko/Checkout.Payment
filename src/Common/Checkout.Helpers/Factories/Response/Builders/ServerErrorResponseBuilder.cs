using Checkout.Helpers.Factories.Response.Models;
using Checkout.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.Helpers.Factories.Response.Builders
{
    /// <summary>
    /// Represents server error response builder.
    /// </summary>
    public class ServerErrorResponseBuilder : IResponseBuilder
    {
        /// <inheritdoc/>
        public IActionResult Build(string errorMessage, string errorCode)
        {
            var error = new ErrorModel { Message = errorMessage, Code = errorCode };
            return new InternalServerErrorObjectResult(error);
        }

        /// <inheritdoc/>
        public IActionResult Build(object model)
        {
            throw new System.NotImplementedException();
        }
    }
}
