using System;
using System.Collections.Generic;

namespace Kandoe.Web.Model.Dto {
    public class AccountDto { 
        public int Id { get; set; }
        public String Email { get; set; }
        public String Name { get; set; }
        public String Picture { get; set; }
        public String Secret { get; set; }
        public String Surname { get; set; }

        public ICollection<ChatMessageDto> ChatMessages { get; set; }
        public ICollection<OrganisationDto> Organisations { get; set; }
        public ICollection<SessionDto> OrganisedSessions { get; set; }
        public ICollection<SessionDto> ParticipatingSessions { get; set; }
        public ICollection<SubthemeDto> Subthemes { get; set; }
        public ICollection<ThemeDto> Themes { get; set; }
    }
}
