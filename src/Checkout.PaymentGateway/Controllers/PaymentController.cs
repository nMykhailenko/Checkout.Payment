using Checkout.Application.Payments.Commands.CreatePayment;
using Checkout.Application.Payments.Query.GetPaymentDetail;
using Checkout.Models.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Checkout.PaymentGateway.Controllers
{
    /// <summary>
    /// Payment controller
    /// </summary>
    [Route("api/[controller]")]
    public class PaymentController : BaseController
    {
        /// <summary>
        /// Initialize payment from merchant.
        /// </summary>
        /// <returns>Action result with payment response model.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(PaymentResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Pay([FromBody]CreatePaymentCommand paymentCommand)
        {
            var response = await Mediator.Send(paymentCommand);
            return ReturnIActionSuccessfulResponse(response, HttpStatusCode.Created);
        }

        /// <summary>
        /// Get payment information by payment unique identifier.
        /// </summary>
        /// <param name="id">Transaction request id.</param>
        /// <returns>Payment information.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PaymentDetailResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(string id)
        {
            var response = await Mediator.Send(new GetPaymentDetailQuery { RequestId = id });
            return ReturnIActionSuccessfulResponse(response, HttpStatusCode.OK);
        }
    }
}
