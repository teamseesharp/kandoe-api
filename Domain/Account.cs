using System;
using System.Collections.Generic;

namespace Kandoe.Business.Domain {
    public class Account {
        protected Account() { }
        public Account(String email, String name, String surname, String picture, String secret) {
            this.Email = email;
            this.Name = name;
            this.Picture = picture;
            this.Secret = secret;
            this.Surname = surname;
        }

        public int Id { get; set; }
        public String Email { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Picture { get; set; }
        public String Secret { get; set; }
        
        public ICollection<ChatMessage> ChatMessages { get; set; }
        public ICollection<Organisation> Organisations { get; set; }
        public ICollection<Session> OrganisedSessions { get; set; }
        public ICollection<Session> ParticipatingSessions { get; set; }
        public ICollection<Subtheme> Subthemes { get; set; }
        public ICollection<Theme> Themes { get; set; }
    }
}
