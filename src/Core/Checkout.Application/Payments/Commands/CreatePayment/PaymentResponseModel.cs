using AutoMapper;
using Checkout.Application.Common.Mappings;
using Checkout.Domain.Entitities;
using Checkout.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Application.Payments.Commands.CreatePayment
{
    /// <summary>
    /// Payment response model.
    /// </summary>
    public class PaymentResponseModel : IMapFrom<Payment>
    {
        /// <summary>
        /// Gets or sets an id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets a request id.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets or sets a state.
        /// </summary>
        public TransactionStateEnum State { get; set; }

        /// <summary>
        /// Mapping.
        /// </summary>
        /// <param name="profile"></param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Payment, PaymentResponseModel>()
                .ForMember(x => x.RequestId, opt => opt.MapFrom(src => src.Transaction.RequestId))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.State, opt => opt.MapFrom(src => src.Transaction.State));
        }
    }
}
