using System;

namespace Kandoe.Business.Domain {
    public class Card {
        public Card(String image, int subthemeId, String text) {
            this.Image = image;
            this.SubthemeId = subthemeId;
            this.Text = text;
        }

        public int Id { get; set; }
        public String Image { get; protected set; }
        public int SubthemeId { get; protected set; }
        public String Text { get; protected set; }
    }
}
