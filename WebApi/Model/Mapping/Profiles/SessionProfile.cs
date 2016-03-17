using System;
using AutoMapper;

using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;
using Kandoe.Web.Model.Mapping.Actions;

namespace Kandoe.Web.Model.Mapping.Profiles {
    public class SessionProfile : Profile {
        protected override void Configure() {
            this.CreateMap<Session, SessionDto>()
                .AfterMap<SortChatMessagesByDatetime>()
                .AfterMap<FilterSessionCircularReferences>();

            this.CreateMap<SessionDto, Session>()
                .ConstructUsing(
                    dto => new Session(
                        dto.CardCreationAllowed,
                        dto.CurrentPlayerIndex,
                        dto.Description,
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