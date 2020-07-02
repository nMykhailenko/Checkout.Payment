using Checkout.Enums;
using Checkout.Helpers.Factories.Response;
using Checkout.Models.ResponseModel;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Checkout.Filters
{
    /// <summary>
    /// Validation filter.
    /// </summary>
    public class ValidationFilter : IAsyncActionFilter
    {
        /// <summary>
        /// Action executing.
        /// </summary>
        /// <param name="context">Executing context.</param>
        /// <param name="next">Executing delegate.</param>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(pair => pair.Key, pair => pair.Value.Errors.Select(x => x.ErrorMessage))
                    .ToArray();

                var errorResponse = new ErrorResponseModel();
                foreach (var error in errorsInModelState)
                {
                    foreach (var subError in error.Value)
                    {
                        errorResponse.Errors.Add(new ValidationResponseModel
                        {
                            FieldName = error.Key,
                            Message = subError
                        });
                    }
                }

                context.Result = ResponseResult
                    .InitializeFactories()
                    .ExecuteCreation(ResponseTypeEnum.Error, HttpStatusCode.BadRequest)
                    .Build(errorResponse);

                return;
            }
            await next();
        }
    }
}
