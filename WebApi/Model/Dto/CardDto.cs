using System;
using System.Collections.Generic;

namespace Kandoe.Web.Model.Dto {
    public class CardDto {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public String Image { get; set; }
        public int SubthemeId { get; set; }
        public String Text { get; set; }

        public ICollection<SubthemeDto> Subthemes { get; set; }
        public ICollection<SessionDto> Sessions { get; set; }
        public ICollection<CardReviewDto> CardReviews { get; set; }
    }
}
