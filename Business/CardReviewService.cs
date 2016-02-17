using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Repositories;

namespace Kandoe.Business {
    public class CardReviewService : Service<CardReview> {
        public CardReviewService() : base(new CardReviewRepository()) { }
    }
}
