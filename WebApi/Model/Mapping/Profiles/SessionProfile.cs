using AutoMapper;

using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Model.Mapping {
    public class SessionProfile : Profile {
        protected override void Configure() {
            this.CreateMap<Session, SessionDto>();

            this.CreateMap<SessionDto, Session>()
                .ConstructUsing(
                    dto => new Session(
                        dto.CardCreationAllowed,
                        dto.CardReviewsAllowed,
                        dto.CurrentPlayerId,
                        dto.IsFinished,
                        dto.MaxCardsToChoose,
                        dto.MaxParticipants,
                        dto.Modus,
                        dto.OrganisationId,
                        dto.Round,
                        dto.SubthemeId,
                        dto.Start,
                        dto.End
                    ));
        }
    }
}