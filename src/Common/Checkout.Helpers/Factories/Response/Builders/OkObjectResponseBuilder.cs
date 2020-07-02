using Microsoft.AspNetCore.Mvc;

namespace Checkout.Helpers.Factories.Response.Builders
{
    /// <summary>
    /// Represents nocontent response builder.
    /// </summary>
    public class OkObjectResponseBuilder : IResponseBuilder
    {
        /// <inheritdoc/>
        public IActionResult Build(string errorMessage, string errorCode)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public IActionResult Build(object model)
        {
            return new OkObjectResult(model);
        }
    }
}
