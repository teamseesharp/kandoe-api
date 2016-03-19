﻿namespace Kandoe.Business.Domain {
    public class SessionCard : Entity {
        protected SessionCard() { }

        public SessionCard(string image, int sessionId, string text, int sessionLevel = 10, int? snapshotId = null) {
            this.Image = image;
            this.SessionId = sessionId;
            this.SessionLevel = sessionLevel;
            this.SnapshotId = snapshotId;
            this.Text = text;
        }

        public string Image { get; set; }
        public int SessionId { get; set; }
        public int? SnapshotId { get; set; }
        public int SessionLevel { get; set; }
        public string Text { get; set; }
    }
}
