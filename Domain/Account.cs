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

        public ICollection<Card> Cards { get; set; }
        public ICollection<CardReview> CardReviews { get; set; }
        public ICollection<ChatMessage> ChatMessages { get; set; }
        public ICollection<Organisation> Organisations { get; set; }
        public ICollection<Session> OrganisedSessions { get; set; }
        public ICollection<Session> ParticipatingSessions { get; set; }
        public ICollection<Subtheme> Subthemes { get; set; }
        public ICollection<Theme> Themes { get; set; }
    }
}
