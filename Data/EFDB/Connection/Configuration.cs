using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;

namespace Kandoe.Data.EFDB.Connection {
    public class Configuration : DbConfiguration {
        public Configuration() {
            this.SetDefaultConnectionFactory(new SqlConnectionFactory());

            this.SetProviderServices("System.Data.SqlClient", SqlProviderServices.Instance);
        }
    }
}
