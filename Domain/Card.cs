using System;
using System.Collections.Generic;

namespace Kandoe.Business.Domain {
    public class Card {
        protected Card() { }
        public Card(int creatorId, String image, int subthemeId, String text) {
            this.CreatorId = creatorId;
            this.Image = image;
            this.SubthemeId = subthemeId;
            this.Text = text;
        }

        public int Id { get; set; }
        public int CreatorId { get; protected set; }
        public String Image { get; protected set; }
        public int SubthemeId { get; protected set; }
        public String Text { get; protected set; }

        public ICollection<Subtheme> Subthemes { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public ICollection<CardReview> CardReviews { get; set; }
    }
}
