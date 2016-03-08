using System;
using System.Collections.Generic;

namespace Kandoe.Business.Domain {
    public class Subtheme {
        protected Subtheme() { }
        public Subtheme(String name, int organiserId, int themeId) {
            this.Name = name;
            this.OrganiserId = organiserId;
            this.ThemeId = themeId;
        }

        public int Id { get; set; }
        public String Name { get; protected set; }
        public int OrganiserId { get; protected set; }
        public int ThemeId { get; protected set; }

        public ICollection<SelectionCard> SelectionCards { get; set; }
        public ICollection<Session> Sessions { get; set; }
    }
}
