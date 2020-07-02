namespace Checkout.Models.Models
{
    /// <summary>
    /// Class describe error model.
    /// </summary>
    public class ErrorModel
    {
        /// <summary>
        /// Gets or sets an error message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets an error code.
        /// </summary>
        public string Code { get; set; }
    }
}
