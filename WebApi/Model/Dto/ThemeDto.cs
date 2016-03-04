using System;
using System.Collections.Generic;

namespace Kandoe.Web.Model.Dto {
    public class ThemeDto {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int OrganisationId { get; set; }
        public int OgraniserId { get; set; }
        public String Tags { get; set; }

        public ICollection<SubthemeDto> Subthemes { get; set; }
    }
}
