using System;

namespace Kandoe.Web.Api.Models.Dto {
    public class Subtheme {
        public int Id { get; set; }
        public String Name { get; set; }
        public int ThemeId { get; set; }
    }
}
