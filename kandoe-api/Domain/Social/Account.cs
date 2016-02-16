using System;

namespace Kandoe.Business.Domain {
    public class Account { 
        public Account(String email, String name, String picture, String secret) {
            this.Email = email;
            this.Name = name;
            this.Picture = picture;
            this.Secret = secret;
        }

        public int Id { get; set; }
        public String Email { get; private set; }
        public String Name { get; private set; }
        public String Picture { get; private set; }
        public String Secret { get; private set; }
        public String Token { get; private set; }

    }
}
