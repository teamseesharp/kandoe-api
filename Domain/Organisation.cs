using System;
using System.Collections.Generic;

namespace Kandoe.Business.Domain {
    public class Organisation {
        protected Organisation() { }
        public Organisation(String name, int organiserId) {
            this.Name = name;
            this.OrganiserId = organiserId;
        }
        
        public int Id { get; set; }
        public String Name { get; protected set; }
        public int OrganiserId { get; protected set; }

        public virtual ICollection<Session> Sessions { get; set; }
        public virtual ICollection<Theme> Themes { get; set; }
    }
}
