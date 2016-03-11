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
        public String Name { get; set; }
        public int OrganiserId { get; set; }

        public ICollection<SelectionCard> Cards { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public ICollection<Theme> Themes { get; set; }
    }
}
