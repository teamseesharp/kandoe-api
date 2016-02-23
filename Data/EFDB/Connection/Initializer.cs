using Kandoe.Business.Domain;
using System.Data.Entity;

namespace Kandoe.Data.EFDB.Connection {
    public class Initializer : DropCreateDatabaseAlways<Context> {
        protected override void Seed(Context context) {
            //base.Seed(context);
            var card = new Card("testImage", 0, "testText");
            context.Cards.Add(card);
            context.SaveChanges();
        }
    }
}
