using System.Collections.Generic;

namespace Kandoe.Web.Model.Dto {
    public class AccountDto { 
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Secret { get; set; }
        public string Surname { get; set; }

        public ICollection<ChatMessageDto> ChatMessages { get; set; }
        public ICollection<OrganisationDto> Organisations { get; set; }
        public ICollection<SessionDto> OrganisedSessions { get; set; }
        public ICollection<SessionDto> ParticipatingSessions { get; set; }
        public ICollection<SubthemeDto> Subthemes { get; set; }
        public ICollection<ThemeDto> Themes { get; set; }
    }
}
