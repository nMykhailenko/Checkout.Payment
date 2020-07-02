using Checkout.Domain.Entitities;
using Checkout.Application.Common.Mappings;
using Checkout.Enums;
using AutoMapper;

namespace Checkout.Application.Payments.Query.GetPaymentDetail
{
    public class PaymentDetailResponseModel : IMapFrom<Payment>
    {
        /// <summary>
        /// Request Id in Payment Gateway.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Payment identifier from bank.
        /// </summary>
        public string BankRequestId { get; set; }

        /// <summary>
        /// Transaction status.
        /// </summary>
        public TransactionStateEnum State { get; set; }

        /// <summary>
        /// Masked card number;
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Credit card holder.
        /// </summary>
        public string CardHolder { get; set; }

        /// <summary>
        /// Mapping.
        /// </summary>
        /// <param name="profile"></param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Payment, PaymentDetailResponseModel>()
                .ForMember(x => x.RequestId, opt => opt.MapFrom(src => src.Transaction.RequestId))
                .ForMember(x => x.BankRequestId, opt => opt.MapFrom(src => src.Transaction.BankRequestId))
                .ForMember(x => x.CardNumber, opt => opt.MapFrom(src => src.CardInformation.CardNumber))
                .ForMember(x => x.CardHolder, opt => opt.MapFrom(src => src.CardInformation.CardHolder))
                .ForMember(x => x.State, opt => opt.MapFrom(src => src.Transaction.State));
        }
    }
}
