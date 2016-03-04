using System;

namespace Kandoe.Business.Domain {
    public class CardReview {
        protected CardReview() { }
        public CardReview(int cardId, String comment, int reviewerId) {
            this.ReviewerId = reviewerId;
            this.CardId = cardId;
            this.Comment = comment;
        }

        public int Id { get; set; }
        public int CardId { get; protected set; }
        public String Comment { get; protected set; }
        public int ReviewerId { get; protected set; }
    }
}
