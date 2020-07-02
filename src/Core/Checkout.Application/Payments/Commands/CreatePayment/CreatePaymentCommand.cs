using AutoMapper;
using Checkout.Domain.Entitities;
using Checkout.Domain.ValueObjects;
using Checkout.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Checkout.Application.Payments.Commands.CreatePayment
{
    /// <summary>
    /// Class describes create payment command.
    /// </summary>
    public class CreatePaymentCommand : IRequest<PaymentResponseModel>
    {
        /// <summary>
        /// Amount of the payment.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Credit card number.
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Credit card holder.
        /// </summary>
        public string CardHolder { get; set; }

        /// <summary>
        /// Credit card expiration month.
        /// </summary>
        public int ExpireMonth { get; set; }

        /// <summary>
        /// Creadit card expiration year.
        /// </summary>
        public int ExpireYear { get; set; }

        /// <summary>
        /// Credit card CVV.
        /// </summary>
        public string CVV { get; set; }

        /// <summary>
        /// User id.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Create payment command handler.
        /// </summary>
        public class Handler : IRequestHandler<CreatePaymentCommand, PaymentResponseModel>
        {
            private readonly CheckoutDbContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;

            public Handler(CheckoutDbContext context, IMediator mediator, IMapper mapper)
            {
                _context = context;
                _mediator = mediator;
                _mapper = mapper;
            }

            public async Task<PaymentResponseModel> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
            {
                var entity = new Payment
                {
                    CardInformation = new CardInformation(request.CardNumber, request.CardHolder),
                    Transaction = new Transaction { Amount = request.Amount, UserId = request.UserId }
                };

                _context.Payments.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);

                var paymentCreated = new PaymentCreated
                {
                    Id = entity.Id,
                    RequestId = entity.Transaction.RequestId,
                    State = entity.Transaction.State
                };

                await _mediator.Publish(paymentCreated, cancellationToken);

                return _mapper.Map<PaymentResponseModel>(entity);
            }
        }
    }
}
