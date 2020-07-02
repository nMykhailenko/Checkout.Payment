using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.Helpers.Factories.Response.Models
{
    /// <summary>
    /// Represents custom ObjectResult for a created result.
    /// </summary>
    public class CreatedObjectResult : ObjectResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatedObjectResult"/> class.
        /// </summary>
        /// <param name="value">A created object result.</param>
        public CreatedObjectResult(object value)
            : base(value)
        {
            StatusCode = StatusCodes.Status201Created;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreatedObjectResult"/> class.
        /// </summary>
        public CreatedObjectResult()
            : this(null)
        {
            StatusCode = StatusCodes.Status201Created;
        }
    }
}
