using System.Collections.Generic;

using AutoMapper;

using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Model.Mapping {
    public class CardProfile : Profile {
        protected override void Configure() {
            this.CreateMap<Card, CardDto>();
            this.CreateMap<CardDto, Card>();
        }
    }
}