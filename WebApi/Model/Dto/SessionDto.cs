using System;

using Kandoe.Business.Domain;

namespace Kandoe.Web.Model.Dto {
    public class SessionDto {
        public int Id { get; set; }
        public DateTime End { get; set; }
        public Modus Modus { get; set; }
        public DateTime Start { get; set; }
    }
}
