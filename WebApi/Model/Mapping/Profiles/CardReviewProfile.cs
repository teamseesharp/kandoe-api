using System.Collections.Generic;

using AutoMapper;

using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Model.Mapping {
    public class CardReviewProfile : Profile {
        protected override void Configure() {
            this.CreateMap<CardReview, CardReviewDto>();
            this.CreateMap<CardReviewDto, CardReview>();
        }
    }
}