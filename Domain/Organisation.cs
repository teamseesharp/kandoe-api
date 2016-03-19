using System.Collections.Generic;

namespace Kandoe.Business.Domain {
    public class Organisation : Entity {
        protected Organisation() { }

        public Organisation(string name, int organiserId) {
            this.Name = name;
            this.OrganiserId = organiserId;
        }
        
        public string Name { get; set; }
        public int OrganiserId { get; set; }
        
        public ICollection<Session> Sessions { get; set; }
        public ICollection<Theme> Themes { get; set; }
    }
}
