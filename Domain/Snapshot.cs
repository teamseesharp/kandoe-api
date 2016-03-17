using System.Collections.Generic;

namespace Kandoe.Business.Domain {
    public class Snapshot {
        protected Snapshot() { }
        public Snapshot(int sessionId, string organisers, string participants) {
            this.SessionId = sessionId;
            this.Organisers = organisers;
            this.Participants = participants;
        }

        public int Id { get; set; }
        public int SessionId { get; set; }

        public string Organisers { get; set; }
        public string Participants { get; set; }

        public ICollection<SessionCard> SessionCards { get; set; }
        public ICollection<ChatMessage> ChatMessages { get; set; }
    }
}
