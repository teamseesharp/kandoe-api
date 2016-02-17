using System.Data.Entity;

namespace Kandoe.Data.EFDB.Connection {
    public class Initialiser : CreateDatabaseIfNotExists<Context> {
        protected override void Seed(Context context) {
            base.Seed(context);
        }
    }
}
