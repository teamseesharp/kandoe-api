using System;
using System.Collections.Generic;

namespace Kandoe.Business.Domain {
    public class Session {
        protected Session() { }
        public Session(bool cardCreationAllowed,int currentPlayerId, bool isFinished, int maxCardsToChoose, int maxParticipants, Modus modus, int organisationId, int round, int subthemeId, DateTime start, DateTime end) {
            this.CardCreationAllowed = cardCreationAllowed;
            this.CurrentPlayerIndex = currentPlayerId;
            this.IsFinished = isFinished;
            this.End = end;
            this.MaxCardsToChoose = maxCardsToChoose;
            this.MaxParticipants = maxParticipants;
            this.Modus = modus;
            this.OrganisationId = organisationId;
            this.Round = round;
            this.SubthemeId = subthemeId;
            this.Start = start;
        }

        public int Id { get; set; }
        public bool CardCreationAllowed { get; protected set; }
        public int CurrentPlayerIndex { get; protected set; }
        public DateTime End { get; protected set; }
        public bool IsFinished { get; protected set; }
        public int MaxCardsToChoose { get; protected set; }
        public int MaxParticipants { get; protected set; }
        public Modus Modus { get; protected set; }
        public int OrganisationId { get; protected set; }
        public int Round { get; protected set; }
        public int SubthemeId { get; protected set; }
        public DateTime Start { get; protected set; }

        public ICollection<SessionCard> SessionCards { get; set; }
        public ICollection<ChatMessage> ChatMessages { get; set; }
        public ICollection<Account> Organisers { get; set; }
        public ICollection<Account> Participants { get; set; }
    }

    public enum Modus {
        Async,
        Sync
    }
}
