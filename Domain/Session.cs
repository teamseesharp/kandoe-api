using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kandoe.Business.Domain {
    public class Session {
        protected Session() { }


        public Session(Modus modus, DateTime start, DateTime end) {
            this.End = end;
            this.Modus = modus;
            this.Start = start;
        }


        public int Id { get; set; }
        public DateTime End { get; protected set; }
        public Modus Modus { get; protected set; }
        public DateTime Start { get; protected set; }
    }

    public enum Modus {
        Async,
        Sync
    }
}
