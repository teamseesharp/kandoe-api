using System;

namespace Kandoe.Business.Domain {
    public class CardReview {
        public CardReview(int accountId, int cardId, String comment, int sessionId) {
            this.AccountId = accountId;
            this.CardId = cardId;
            this.Comment = comment;
            this.SessionId = sessionId;
        }

        public int Id { get; set; }
        public int AccountId { get; private set; }
        public int CardId { get; private set; }
        public String Comment { get; private set; }
        public int SessionId { get; private set; }
    }
}
