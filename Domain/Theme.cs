using System.Collections.Generic;

namespace Kandoe.Business.Domain {
    public class Theme : Entity {
        protected Theme() { }

        public Theme(string name, string description, int organisationId, int organiserId, string tags) {
            this.Name = name;
            this.Description = description;
            this.OrganisationId = organisationId;
            this.OrganiserId = organiserId;
            this.Tags = tags;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int OrganisationId { get; set; }
        public int OrganiserId { get; set; }
        public string Tags { get; set; }

        public ICollection<SelectionCard> SelectionCards { get; set; }
        public ICollection<Subtheme> Subthemes { get; set; }
    }
}
