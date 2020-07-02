﻿using Checkout.Application.Payments.Commands.CreatePayment;
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
    public class PaymentController : BaseController
    {
        /// <summary>
        /// Initialize payment from merchant.
        /// </summary>
        /// <returns>Action result with payment response model.</returns>
        [HttpPost]
        [Route("api/payment")]
        [ProducesResponseType(typeof(PaymentResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Pay([FromBody]CreatePaymentCommand paymentCommand)
        {
            var response = await Mediator.Send(paymentCommand);
            return ReturnIActionSuccessfulResponse(response, HttpStatusCode.Created);
        }
    }
}
