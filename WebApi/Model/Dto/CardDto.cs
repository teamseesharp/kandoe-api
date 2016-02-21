using System;

namespace Kandoe.Web.Model.Dto {
    public class CardDto {
        public int Id { get; set; }
        public String Image { get; set; }
        public int SubthemeId { get; set; }
        public String Text { get; set; }
    }
}
