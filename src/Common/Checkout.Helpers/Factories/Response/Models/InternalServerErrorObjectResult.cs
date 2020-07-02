using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.Helpers.Factories.Response.Models
{
    /// <summary>
    /// Represents custom ObjectResult for the internal server error.
    /// </summary>
    public class InternalServerErrorObjectResult : ObjectResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InternalServerErrorObjectResult"/> class.
        /// </summary>
        /// <param name="value">An error details.</param>
        public InternalServerErrorObjectResult(object value)
            : base(value)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InternalServerErrorObjectResult"/> class.
        /// </summary>
        public InternalServerErrorObjectResult()
            : this(null)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
