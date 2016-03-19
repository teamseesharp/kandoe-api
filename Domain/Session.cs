using System;
using System.Collections.Generic;

namespace Kandoe.Business.Domain {
    public class Session : Entity {
        protected Session() { }
        public Session(bool cardCreationAllowed,int currentPlayerIndex, string description, bool isFinished, int maxCardsToChoose, int maxParticipants, int organisationId, int round, int subthemeId, DateTime start, DateTime end) {
            this.CardCreationAllowed = cardCreationAllowed;
            this.CurrentPlayerIndex = currentPlayerIndex;
            this.Description = description;
            this.IsFinished = isFinished;
            this.End = end;
            this.MaxCardsToChoose = maxCardsToChoose;
            this.MaxParticipants = maxParticipants;
            this.OrganisationId = organisationId;
            this.Round = round;
            this.SubthemeId = subthemeId;
            this.Start = start;
        }

        public bool CardCreationAllowed { get; set; }
        public int CurrentPlayerIndex { get; set; }
        public string Description { get; set; }
        public DateTime End { get; set; }
        public bool IsFinished { get; set; }
        public int MaxCardsToChoose { get; set; }
        public int MaxParticipants { get; set; }
        public int OrganisationId { get; set; }
        public int Round { get; set; }
        public int SubthemeId { get; set; }
        public DateTime Start { get; set; }

        public ICollection<ChatMessage> ChatMessages { get; set; }
        public ICollection<Account> Invitees { get; set; }
        public ICollection<Account> Organisers { get; set; }
        public ICollection<Account> Participants { get; set; }
        public ICollection<SessionCard> SessionCards { get; set; }
    }
}
