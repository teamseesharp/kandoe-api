using System;

namespace Kandoe.Business.Domain {
    public class ChatMessage {
        protected ChatMessage() { }
        public ChatMessage(String text) {
            this.Text = text;
        }

        public int Id { get; set; }
        public String Text { get; protected set; }
    }
}
