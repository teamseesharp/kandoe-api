using System.Collections.Generic;

namespace Kandoe.Web.Model.Dto {
    public class OrganisationDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrganiserId { get; set; }

        public ICollection<SessionDto> Sessions { get; set; }
        public ICollection<ThemeDto> Themes { get; set; }
    }
}
