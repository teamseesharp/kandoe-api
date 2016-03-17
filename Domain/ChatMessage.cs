using System;

namespace Kandoe.Business.Domain {
    public class ChatMessage {
        protected ChatMessage() { }
        public ChatMessage(int messengerId, int sessionId, String text, DateTime timestamp, int? snapshotId = null) {
            this.MessengerId = messengerId;
            this.SessionId = sessionId;
            this.SnapshotId = snapshotId;
            this.Text = text;
            this.Timestamp = timestamp;
        }

        public int Id { get; set; }
        public int MessengerId { get; set; }
        public int SessionId { get; set; }
        public int? SnapshotId { get; set; }
        public String Text { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
