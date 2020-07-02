using Checkout.Enums;
using Checkout.Helpers.Factories.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace Checkout.PaymentGateway.Controllers
{
    /// <summary>
    /// Class describes base controller.
    /// </summary>
    public class BaseController : Controller
    {
        private IMediator _mediator;

        /// <summary>
        /// Mediator
        /// </summary>
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        /// <summary>
        /// Gets an error IAction Result.
        /// </summary>
        /// <param name="errorMessage">An error message.</param>
        /// <param name="statusCode">The http status code.</param>
        /// <returns>IActionResult with error model.</returns>
        public IActionResult ReturnIActionErrorResponse(string errorMessage, HttpStatusCode statusCode)
        {
            var result = ResponseResult
                .InitializeFactories()
                .ExecuteCreation(ResponseTypeEnum.Error, statusCode)
                .Build(errorMessage);

            return result;
        }

        /// <summary>
        /// Gets an error IAction Result.
        /// </summary>
        /// <param name="errorModel">An error model.</param>
        /// <param name="statusCode">The http status code.</param>
        /// <returns>IActionResult with error model.</returns>
        public IActionResult ReturnIActionErrorResponse(object errorModel, HttpStatusCode statusCode)
        {
            var result = ResponseResult
                .InitializeFactories()
                .ExecuteCreation(ResponseTypeEnum.Error, statusCode)
                .Build(errorModel);

            return result;
        }

        /// <summary>
        /// Gets an error IAction Result.
        /// </summary>
        /// <param name="model">A model to return.</param>
        /// <param name="statusCode">The http status code.</param>
        /// <returns>IActionResult with error model.</returns>
        public IActionResult ReturnIActionSuccessfulResponse(object model, HttpStatusCode statusCode)
        {
            var result = ResponseResult
                .InitializeFactories()
                .ExecuteCreation(ResponseTypeEnum.Success, statusCode)
                .Build(model);

            return result;
        }
    }
}
