using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Repositories;

namespace Kandoe.Business{
    public class SnapshotService: Service<Snapshot> {
        public SnapshotService() : base(new SnapshotRepository()) { }
    }
}
