using System;

namespace Kandoe.Web.Model.Dto {
    public class AccountDto { 
        public int Id { get; set; }
        public String Email { get; set; }
        public String Name { get; set; }
        public String Picture { get; set; }
        public String Secret { get; set; }
        public String Surname { get; set; }
    }
}
