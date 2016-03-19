using AutoMapper;

using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Model.Mapping.Profiles {
    public class SessionCardProfile : Profile {
        protected override void Configure() {
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