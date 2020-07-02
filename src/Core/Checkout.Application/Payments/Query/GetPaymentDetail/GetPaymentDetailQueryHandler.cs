using AutoMapper;
using Checkout.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Checkout.Application.Payments.Query.GetPaymentDetail
{
    public class GetPaymentDetailQueryHandler : IRequestHandler<GetPaymentDetailQuery, PaymentDetailResponseModel>
    {
        private readonly CheckoutDbContext _context;
        private readonly IMapper _mapper;

        public GetPaymentDetailQueryHandler(CheckoutDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaymentDetailResponseModel> Handle(GetPaymentDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Payments
                .Include(x => x.Transaction)
                .FirstOrDefaultAsync(x => x.Transaction.RequestId == request.RequestId);

            if (entity == null) throw new ArgumentNullException();

            return _mapper.Map<PaymentDetailResponseModel>(entity);
        }
    }
}
