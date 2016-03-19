using System;

namespace Kandoe.Business.Domain {
    public class ChatMessage : Entity {
        protected ChatMessage() { }

        public ChatMessage(int messengerId, int sessionId, string text, DateTime timestamp, int? snapshotId = null) {
            this.MessengerId = messengerId;
            this.SessionId = sessionId;
            this.SnapshotId = snapshotId;
            this.Text = text;
            this.Timestamp = timestamp;
        }

        public int MessengerId { get; set; }
        public int SessionId { get; set; }
        public int? SnapshotId { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
