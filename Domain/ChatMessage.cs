using System;

namespace Kandoe.Business.Domain {
    public class ChatMessage : Entity {
        protected ChatMessage() { }

        public ChatMessage(int messengerId, int sessionId, string text, DateTime timestamp) {
            this.MessengerId = messengerId;
            this.SessionId = sessionId;
            this.Text = text;
            this.Timestamp = timestamp;
        }

        public int MessengerId { get; set; }
        public int SessionId { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
