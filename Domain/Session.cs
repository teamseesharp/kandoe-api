using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kandoe.Business.Domain {
    public class Session {
        public Session(Modus modus) {
            this.Modus = modus;
        }

        public int Id { get; set; }
        public Modus Modus { get; private set; }
    }

    public enum Modus {
        Async,
        Sync
    }
}
