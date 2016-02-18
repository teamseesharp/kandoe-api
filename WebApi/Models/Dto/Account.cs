using System;

namespace Kandoe.Web.Api.Models.Dto {
    public class Account { 
        public int Id { get; set; }
        public String Email { get; set; }
        public String Name { get; set; }
        public String Picture { get; set; }
        public String Secret { get; set; }
    }
}
