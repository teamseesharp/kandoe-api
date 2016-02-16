using System;

namespace Kandoe.Business.Domain {
    public class Card {
        public Card(String image, int subthemeId, String text) {
            this.Image = image;
            this.Text = text;
        }

        public int Id { get; set; }
        public String Image { get; private set; }
        public int SubthemeId { get; private set; }
        public String Text { get; private set; }
    }
}
