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
        public String Name { get; protected set; }
        public String Description { get; protected set; }
        public int OrganisationId { get; protected set; }
        public int OrganiserId { get; protected set; }
        public String Tags { get; protected set; }

        public ICollection<SelectionCard> SelectionCards { get; set; }
        public ICollection<Subtheme> Subthemes { get; set; }
    }
}
