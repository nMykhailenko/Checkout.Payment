using Checkout.Helpers.Factories.Response.Builders;
using Checkout.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.Services.Factories.Response.Builders
{
    /// <summary>
    /// Represents BadRequest response builder.
    /// </summary>
    public class BadRequestResponseBuilder : IResponseBuilder
    {
        /// <inheritdoc/>
        public IActionResult Build(string errorMessage, string errorCode)
        {
            var error = new ErrorModel { Message = errorMessage, Code = errorCode };
            return new BadRequestObjectResult(error);
        }

        /// <inheritdoc/>
        public IActionResult Build(object model)
        {
            return new BadRequestObjectResult(model);
        }
    }
}
