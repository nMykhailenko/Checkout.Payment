using Checkout.Enums;
using Checkout.Helpers.Factories.Response.Builders;
using System.Collections.Generic;
using System.Net;

namespace Checkout.Helpers.Factories.Response
{
    /// <summary>
    /// Represents response result of the operation execution.
    /// </summary>
    public class ResponseResult
    {
        private readonly Dictionary<ResponseTypeEnum, ResponseResultBuilderFactory> _factories;

        private ResponseResult()
        {
            _factories = new Dictionary<ResponseTypeEnum, ResponseResultBuilderFactory>()
            {
                { ResponseTypeEnum.Error, new ErrorResponseResultBuilderFactory() },
                { ResponseTypeEnum.Success, new SuccessResponseResultBuilderFactory() }
            };
        }

        /// <summary>
        /// Initialize factories.
        /// </summary>
        /// <returns>Instance if ResponseResult.</returns>
        public static ResponseResult InitializeFactories() => new ResponseResult();

        /// <summary>
        /// Creates response depending on response type and status code.
        /// </summary>
        /// <param name="responseType">Response type.</param>
        /// <param name="statusCode">Http status code.</param>
        /// <returns>Instance of <see cref="IActionResult"/>.</returns>
        public IResponseBuilder ExecuteCreation(ResponseTypeEnum responseType, HttpStatusCode statusCode)
            => _factories[responseType].Create(statusCode);
    }
}
