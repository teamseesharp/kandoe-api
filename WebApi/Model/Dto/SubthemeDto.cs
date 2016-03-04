using System;
using System.Collections.Generic;

namespace Kandoe.Web.Model.Dto {
    public class SubthemeDto {
        public int Id { get; set; }
        public String Name { get; set; }
        public int OrganiserId { get; set; }
        public int ThemeId { get; set; }

        public ICollection<SessionDto> Sessions { get; set; }
        public ICollection<CardDto> Cards { get; set; }
    }
}
