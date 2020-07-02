using System.Collections.Generic;

namespace Checkout.Models.ResponseModel
{
    /// <summary>
    /// Class describe validation error response.
    /// </summary>
    public class ErrorResponseModel
    {
        /// <summary>
        /// Gets or sets a validation errors.
        /// </summary>
        public List<ValidationResponseModel> Errors { get; set; } = new List<ValidationResponseModel>();
    }
}
