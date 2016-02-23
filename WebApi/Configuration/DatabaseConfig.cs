using System.Data.Entity.Migrations;
using System.Linq;

namespace Kandoe.Web.Configuration {
    public static class DatabaseConfig {
        public static void Configure() {
            DbMigrator migrator = new DbMigrator(new Data.Migrations.Configuration());
            if (migrator.GetPendingMigrations().Any()) {
                migrator.Update();
            }
        }
    }
}