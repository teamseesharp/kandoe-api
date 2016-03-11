using System;
using System.Collections.Generic;

namespace Kandoe.Business.Domain {
    public class Theme {
        protected Theme() { }
        public Theme(String name, String description, int organisationId, int organiserId, String tags) {
            this.Name = name;
            this.Description = description;
            this.OrganisationId = organisationId;
            this.OrganiserId = organiserId;
            this.Tags = tags;
        }

        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int OrganisationId { get; set; }
        public int OrganiserId { get; set; }
        public String Tags { get; set; }

        public ICollection<SelectionCard> SelectionCards { get; set; }
        public ICollection<Subtheme> Subthemes { get; set; }
    }
}
