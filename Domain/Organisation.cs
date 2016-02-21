using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kandoe.Business.Domain {
    public class Organisation {
        public Organisation(String name, int organiserId) {
            this.Name = name;
            this.OrganiserId = organiserId;
        }
        
        public int Id { get; set; }
        public String Name { get; protected set; }
        public int OrganiserId { get; protected set; }
    }
}
