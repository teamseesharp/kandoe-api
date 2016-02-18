using System;

namespace Kandoe.Web.Api.Models.Dto {
    public class Card {
        public int Id { get; set; }
        public String Image { get; set; }
        public int SubthemeId { get; set; }
        public String Text { get; set; }
    }
}
