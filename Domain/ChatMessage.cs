using System;

namespace Kandoe.Business.Domain {
    public class ChatMessage {
        protected ChatMessage() { }
        public ChatMessage(int messengerId, int sessionId, String text) {
            this.MessengerId = messengerId;
            this.SessionId = sessionId;
            this.Text = text;
        }

        public int Id { get; set; }
        public int MessengerId { get; protected set; }
        public int SessionId { get; protected set; }
        public String Text { get; protected set; }
    }
}
