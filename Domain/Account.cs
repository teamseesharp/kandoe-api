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
        public String Email { get; protected set; }
        public String Name { get; protected set; }
        public String Surname { get; protected set; }
        public String Picture { get; protected set; }
        public String Secret { get; protected set; }

        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<CardReview> CardReviews { get; set; }
        public virtual ICollection<ChatMessage> ChatMessages { get; set; }
        public virtual ICollection<Organisation> Organisations { get; set; }
        public virtual ICollection<Session> OrganisedSessions { get; set; }
        public virtual ICollection<Session> ParticipatingSessions { get; set; }
        public virtual ICollection<Subtheme> Subthemes { get; set; }
        public virtual ICollection<Theme> Themes { get; set; }
    }
}
