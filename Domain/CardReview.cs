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
        public int AccountId { get; protected set; }
        public int CardId { get; protected set; }
        public String Comment { get; protected set; }
        public int SessionId { get; protected set; }
    }
}
