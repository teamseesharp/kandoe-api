using AutoMapper;

using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Model.Mapping {
    public class CardProfile : Profile {
        protected override void Configure() {
            this.CreateMap<Card, CardDto>();

            this.CreateMap<CardDto, Card>()
                .ConstructUsing(
                    dto => new Card(
                        dto.Image,
                        dto.SubthemeId,
                        dto.Text
                    ));
        }
    }
}