using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kandoe.Business.Domain {
    public class Session {
        protected Session() { }
        

        public Session(Modus modus, DateTime startDate, DateTime endDate)
        {
            this.Modus = modus;
            this.startDate = startDate;
            this.endDate = endDate;
            sessionHistory = new ArrayList();

        }


        public int Id { get; set; }
        public Modus Modus { get; protected set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public ArrayList sessionHistory { get; set; }
    }

    public enum Modus {
        Async,
        Sync
    }
}
