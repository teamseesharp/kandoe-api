using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kandoe.Data.EFDB.Connection {
    public static class ContextFactory {
        private static Context context;

        public static Context GetContext() { return context ?? (context = new Context()); }
    }
}
