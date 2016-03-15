using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kandoe.Business.Domain
{
    public class Snapshot{
        protected Snapshot() { }
        public Snapshot(int sessionId, ICollection<int> participants , ICollection<int> organisers ) {
            this.SessionId = sessionId;
            this.Participants = participants;
            this.Organisers = organisers;
        }


        public int Id { get; set; }
        public int SessionId { get; set; }

        public ICollection<int> Participants { get; set; }
        public ICollection<int> Organisers { get; set; }

        public ICollection<SessionCard> SessionCards { get; set; }
        public ICollection<ChatMessage> ChatMessages { get; set; }


    }
}
