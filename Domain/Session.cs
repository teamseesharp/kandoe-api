using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kandoe.Business.Domain {
    public class Session {
        protected Session() { }
        public Session(Modus modus) {
            this.Modus = modus;
        }

        public int Id { get; set; }
        public Modus Modus { get; protected set; }
    }

    public enum Modus {
        Async,
        Sync
    }
}
