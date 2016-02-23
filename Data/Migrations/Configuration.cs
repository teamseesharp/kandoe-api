using System.Data.Entity.Migrations;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.Migrations {
    public sealed class Configuration : DbMigrationsConfiguration<Context> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context) {
            Card card = new Card("testImage", 0, "testText");
            context.Cards.Add(card);

            card = new Card("testImage2", 1, "testText2");
            context.Cards.Add(card);

            card = new Card("testImage", 0, "testText");
            context.Cards.Add(card);

            context.SaveChanges();

            // seed
            base.Seed(context);
        }
    }
}
