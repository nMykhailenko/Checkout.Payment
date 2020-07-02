using Checkout.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.Helpers.Factories.Response.Builders
{
    /// <summary>
    /// Represents NotFound response builder.
    /// </summary>
    public class NotFoundResponseBuilder : IResponseBuilder
    {
        /// <inheritdoc/>
        public IActionResult Build(string errorMessage, string errorCode)
        {
            var error = new ErrorModel { Message = errorMessage, Code = errorCode };
            return new NotFoundObjectResult(error);
        }

        /// <inheritdoc/>
        public IActionResult Build(object model)
        {
            throw new System.NotImplementedException();
        }
    }
}
