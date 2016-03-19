using System.Collections.Generic;

namespace Kandoe.Web.Model.Dto {
    public class ThemeDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OrganisationId { get; set; }
        public int OrganiserId { get; set; }
        public string Tags { get; set; }

        public ICollection<SelectionCardDto> SelectionCards { get; set; }
        public ICollection<SubthemeDto> Subthemes { get; set; }
    }
}
