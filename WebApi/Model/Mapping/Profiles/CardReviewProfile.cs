using AutoMapper;

using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Model.Mapping {
    public class CardReviewProfile : Profile {
        protected override void Configure() {
            this.CreateMap<CardReview, CardReviewDto>();

            this.CreateMap<CardReviewDto, CardReview>()
                .ConstructUsing(
                    dto => new CardReview (
                        dto.AccountId,
                        dto.CardId,
                        dto.Comment,
                        dto.SessionId
                    ));
        }
    }
}