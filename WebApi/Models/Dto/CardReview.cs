using System;

namespace Kandoe.Web.Api.Models.Dto {
    public class CardReview {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int CardId { get; set; }
        public String Comment { get; set; }
        public int SessionId { get; set; }
    }
}
