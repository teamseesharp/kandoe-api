using System;

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
    }
}
