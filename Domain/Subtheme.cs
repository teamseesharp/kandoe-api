using System;

namespace Kandoe.Business.Domain {
    public class Subtheme {
        public Subtheme(String name, int themeId) {
            this.Name = name;
            this.ThemeId = themeId;
        }

        public int Id { get; set; }
        public String Name { get; protected set; }
        public int ThemeId { get; protected set; }
    }
}
