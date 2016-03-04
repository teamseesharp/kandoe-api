using System;

namespace Kandoe.Web.Model.Dto {
    public class CardReviewDto {
        public int Id { get; set; }
        public int ReviewerId { get; set; }
        public int CardId { get; set; }
        public String Comment { get; set; }
    }
}
