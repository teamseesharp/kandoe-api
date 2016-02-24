using System.Data.Entity.Migrations;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.Migrations {
    public sealed class Configuration : DbMigrationsConfiguration<Context> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context) {
            int cardId = 1;

            Card card = new Card("testImage", 0, "testText");
            card.Id = cardId++;
            context.Cards.AddOrUpdate(card);

            card = new Card("testImage2", 1, "testText2");
            card.Id = cardId++;
            context.Cards.AddOrUpdate(card);

            card = new Card("testImage", 0, "testText");
            card.Id = cardId++;
            context.Cards.AddOrUpdate(card);

            context.SaveChanges();

            // seed
            base.Seed(context);
        }

        private void AddOrUpdate<TEntity>(int id, TEntity entity) {
            // meh
        }
    }
}
