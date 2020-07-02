using Checkout.Helpers.Factories.Response.Models;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.Helpers.Factories.Response.Builders
{
    /// <summary>
    /// Represents created response builder.
    /// </summary>
    public class CreatedResponseBuilder : IResponseBuilder
    {
        /// <inheritdoc/>
        public IActionResult Build(string errorMessage, string errorCode)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public IActionResult Build(object model)
        {
            return new CreatedObjectResult(model);
        }
    }
}
