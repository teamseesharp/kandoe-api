using System.Collections.Generic;

namespace Kandoe.Business.Domain {
    public class Subtheme : Entity {
        protected Subtheme() { }

        public Subtheme(string name, int organiserId, int themeId) {
            this.Name = name;
            this.OrganiserId = organiserId;
            this.ThemeId = themeId;
        }

        public string Name { get; set; }
        public int OrganiserId { get; set; }
        public int ThemeId { get; set; }

        public ICollection<SelectionCard> SelectionCards { get; set; }
        public ICollection<Session> Sessions { get; set; }
    }
}
