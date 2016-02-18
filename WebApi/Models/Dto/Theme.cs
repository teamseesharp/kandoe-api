using System;

namespace Kandoe.Web.Api.Models.Dto {
    public class Theme {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int OrganisationId { get; set; }
        public String Tags { get; set; }
    }
}
