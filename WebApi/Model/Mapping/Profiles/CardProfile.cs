using AutoMapper;

using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Model.Mapping {
    public class CardProfile : Profile {
        protected override void Configure() {
            this.CreateMap<SelectionCard, CardDto>();

            this.CreateMap<CardDto, SelectionCard>()
                .ConstructUsing(
                    dto => new SelectionCard(
                        dto.Image,
                        dto.Text,
                        dto.ThemeId,
                        dto.SubthemeId
                    ));

            this.CreateMap<SessionCard, CardDto>();

            this.CreateMap<CardDto, SessionCard>()
                .ConstructUsing(
                    dto => new SessionCard(
                        dto.Image,
                        dto.SessionId,
                        dto.Text,
                        dto.SessionLevel
                    ));
        }
    }
}