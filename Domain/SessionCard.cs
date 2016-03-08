using System;
using System.Collections.Generic;

namespace Kandoe.Business.Domain {
    public class SessionCard {
        protected SessionCard() { }
        public SessionCard(String image, int sessionId, int sessionLevel, String text) {
            this.Image = image;
            this.SessionId = sessionId;
            this.SessionLevel = sessionLevel;
            this.Text = text;
        }

        public int Id { get; set; }
        public String Image { get; protected set; }
        public int SessionId { get; protected set; }
        public int SessionLevel { get; protected set; }
        public String Text { get; protected set; }
    }
}
