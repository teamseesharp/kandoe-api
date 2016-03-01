using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.Migrations {
    public sealed class Configuration : DbMigrationsConfiguration<Context> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context) {
            int userId = 0;
            int sessionId = 0;
            int themeId = 0;
            int cardId = 0;

            #region UserSeed
            Account account = new Account("thomastvd@gmail.com", "Thomas", "Van Deun", "picture", "auth0|56d4591317aca91f1aff5dfb");
            account.Id = ++userId;
            context.Accounts.AddOrUpdate(account);

            //acc = new Account("michelle@gmail.com", "Michelle", "Beckers", "picture", "", "michelle13245");
            //context.Accounts.AddOrUpdate(acc);

            //acc = new Account("olivier@gmail.com", "Olivier", "Van Aken", "picture", "", "oli12345");
            //context.Accounts.AddOrUpdate(acc);

            account = new Account("helsen.bennie@gmail.com", "Bennie", "Bax", "picture", "google-oauth2|104916923787165182658");
            account.Id = ++userId;
            context.Accounts.AddOrUpdate(account);

            //acc = new Account("joachim@gmail.com", "Joachim", "De Schryver", "picture", "", "joa2345");
            //context.Accounts.AddOrUpdate(acc);

            account = new Account("cas.decelle@gmail.com", "Cas", "Decelle", "picture", "auth0|56d49e6d6568e621399e379c");
            account.Id = ++userId;
            context.Accounts.AddOrUpdate(account);

            account = new Account("cas.decelle@gmail.com", "Cas", "Decelle", "picture", "google-oauth2|112196091859139010399");
            account.Id = ++userId;
            context.Accounts.AddOrUpdate(account);

            context.SaveChanges();
            #endregion

            #region SessionSeed
            Session session = new Session(Modus.Sync, DateTime.Now, DateTime.Now.AddDays(15));
            session.Id = ++sessionId;
            context.Sessions.AddOrUpdate(session);

            session = new Session(Modus.Sync, DateTime.Now, DateTime.Now.AddDays(5));
            session.Id = ++sessionId;
            context.Sessions.AddOrUpdate(session);

            session = new Session(Modus.Async, DateTime.Now, DateTime.Now.AddDays(20));
            session.Id = ++sessionId;
            context.Sessions.AddOrUpdate(session);

            context.SaveChanges();
            #endregion

            #region ThemeSeed
            String tags = "Jeugd;Werken;Geld";

            Theme theme = new Theme("Jongerenwerking", "Hoe laten we de jeugd terug werken", 1, tags);
            theme.Id = ++themeId;
            context.Themes.AddOrUpdate(theme);

            tags = "Toekomst;Werken;Geld";

            theme = new Theme("Armoedebestrijding", "Hoe kunnen we iedereen rijk maken", 1, tags);
            theme.Id = ++themeId;
            context.Themes.AddOrUpdate(theme);

            context.SaveChanges();
            #endregion

            #region CardSeed
            Card card = new Card("testImage", 0, "Armoede");
            card.Id = ++cardId;
            context.Cards.AddOrUpdate(card);

            card = new Card("testImage2", 1, "Jeugdhuis");
            card.Id = ++cardId;
            context.Cards.AddOrUpdate(card);

            card = new Card("testImage", 0, "Werkloosheid");
            card.Id = ++cardId;
            context.Cards.AddOrUpdate(card);
            #endregion

            context.SaveChanges();

            // seed
            base.Seed(context);


        }

        private void AddOrUpdate<TEntity>(int id, TEntity entity) {
            // meh
        }
    }
}
