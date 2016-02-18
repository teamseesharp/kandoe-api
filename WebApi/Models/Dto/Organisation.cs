using System;

namespace Kandoe.Web.Api.Models.Dto {
    public class Organisation {
        public int Id { get; set; }
        public String Name { get; set; }
        public int OrganiserId { get; set; }
    }
}
