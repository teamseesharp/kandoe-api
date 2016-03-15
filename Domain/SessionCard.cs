using System;
using System.Collections.Generic;

namespace Kandoe.Business.Domain {
    public class SessionCard {
        protected SessionCard() { }
        public SessionCard(String image, int sessionId, String text, int sessionLevel = 10, int? snapshotId = null) {
            this.Image = image;
            this.SessionId = sessionId;
            this.SessionLevel = sessionLevel;
            this.SnapshotId = snapshotId;
            this.Text = text;
        }

        public int Id { get; set; }
        public String Image { get; set; }
        public int SessionId { get; set; }
        public int? SnapshotId { get; set; }
        public int SessionLevel { get; set; }
        public String Text { get; set; }
    }
}
