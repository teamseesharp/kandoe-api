using System;

namespace Kandoe.Business.Domain {
    public class Theme {
        protected Theme() { }
        public Theme(String name, String description, int organisationId, String tags) {
            this.Name = name;
            this.Description = description;
            this.OrganisationId = organisationId;
            this.Tags = tags;
        }

        public int Id { get; set; }
        public String Name { get; protected set; }
        public String Description { get; protected set; }
        public int OrganisationId { get; protected set; }
        public String Tags { get; protected set; }
    }
}
