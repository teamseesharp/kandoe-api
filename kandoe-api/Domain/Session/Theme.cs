using System;

namespace Kandoe.Business.Domain {
    public class Theme {
        public Theme(String name, String description, int organisationId, String tags) {
            this.Name = name;
            this.Description = description;
            this.OrganisationId = organisationId;
            this.Tags = tags;
        }

        public int Id { get; set; }
        public String Name { get; private set; }
        public String Description { get; private set; }
        public int OrganisationId { get; private set; }
        public String Tags { get; private set; }
    }
}
