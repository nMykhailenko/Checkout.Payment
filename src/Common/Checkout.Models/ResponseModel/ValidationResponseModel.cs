namespace Checkout.Models.ResponseModel
{
    /// <summary>
    /// Class describes validation response model.
    /// </summary>
    public class ValidationResponseModel
    {
        /// <summary>
        /// Gets or sets a field name.
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// Gets or sets a message.
        /// </summary>
        public string Message { get; set; }
    }
}
