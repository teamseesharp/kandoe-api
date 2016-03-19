using System.Collections.Generic;

namespace Kandoe.Web.Model.Dto {
    public class SubthemeDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrganiserId { get; set; }
        public int ThemeId { get; set; }

        public ICollection<CardDto> SelectionCards { get; set; }
        public ICollection<SessionDto> Sessions { get; set; }
    }
}
