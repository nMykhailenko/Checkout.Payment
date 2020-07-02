using Microsoft.AspNetCore.Mvc;

namespace Checkout.Helpers.Factories.Response.Builders
{
    /// <summary>
    /// An interface describes response builder.
    /// </summary>
    public interface IResponseBuilder
    {
        /// <summary>
        /// Builds response.
        /// </summary>
        /// <param name="errorMessage">An error message text.</param>
        /// <param name="errorCode">An error code.</param>
        /// <returns>An Action result.</returns>
        IActionResult Build(string errorMessage, string errorCode);

        /// <summary>
        /// Builds response.
        /// </summary>
        /// <param name="model">A model to return.</param>
        /// <returns>An Action result.</returns>
        IActionResult Build(object model);
    }
}
