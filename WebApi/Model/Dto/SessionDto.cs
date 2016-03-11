using System;
using System.Collections.Generic;

using Kandoe.Business.Domain;

namespace Kandoe.Web.Model.Dto {
    public class SessionDto {
        public int Id { get; set; }
        public bool CardCreationAllowed { get; set; }
        public int CurrentPlayerId { get; set; }
        public DateTime End { get; set; }
        public bool IsFinished { get; set; }
        public int MaxCardsToChoose { get; set; }
        public int MaxParticipants { get; set; }
        public Modus Modus { get; set; }
        public int OrganisationId { get; set; }
        public int Round { get; set; }
        public int SubthemeId { get; set; }
        public DateTime Start { get; set; }

        public ICollection<CardDto> SessionCards { get; set; }
        public ICollection<ChatMessageDto> ChatMessages { get; set; }
        public ICollection<AccountDto> Organisers { get; set; }
        public ICollection<AccountDto> Participants { get; set; }
    }
}
