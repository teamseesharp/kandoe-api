using System.Collections.Generic;

namespace Kandoe.Business.Domain {
    public class Account : Entity {
        protected Account() { }

        public Account(string email, string name, string surname, string picture, string secret) {
            this.Email = email;
            this.Name = name;
            this.Picture = picture;
            this.Secret = secret;
            this.Surname = surname;
        }

        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; }
        public string Secret { get; set; }
        
        public ICollection<ChatMessage> ChatMessages { get; set; }
        public ICollection<Organisation> Organisations { get; set; }
        public ICollection<Session> OrganisedSessions { get; set; }
        public ICollection<Session> InvitedSessions { get; set; }
        public ICollection<Session> ParticipatingSessions { get; set; }
        public ICollection<Subtheme> Subthemes { get; set; }
        public ICollection<Theme> Themes { get; set; }
    }
}
