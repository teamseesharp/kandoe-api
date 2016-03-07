using System;

namespace Kandoe.Business.Domain {
    public class ChatMessage {
        protected ChatMessage() { }
        public ChatMessage(int messengerId, int sessionId, String text, DateTime timestamp) {
            this.MessengerId = messengerId;
            this.SessionId = sessionId;
            this.Text = text;
            this.Timestamp = timestamp;
        }

        public int Id { get; set; }
        public int MessengerId { get; protected set; }
        public int SessionId { get; protected set; }
        public String Text { get; protected set; }
        public DateTime Timestamp { get; protected set; }
    }
}
