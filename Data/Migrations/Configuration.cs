using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.Migrations {
    public sealed class Configuration : DbMigrationsConfiguration<Context> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Context context) {
            int accountId = 0;
            int sessionId = 0;
            int themeId = 0;
            int subthemeId = 0;
            int cardId = 0;
            int organisationId = 0;

            #region AccountSeed
            Account account = new Account("thomastvd@gmail.com", "Thomas", "Van Deun", "picture", "auth0|56d4591317aca91f1aff5dfb");
            account.Id = ++accountId;
            context.Accounts.AddOrUpdate(account);

            //acc = new Account("michelle@gmail.com", "Michelle", "Beckers", "picture", "", "michelle13245");
            //context.Accounts.AddOrUpdate(acc);

            //acc = new Account("olivier@gmail.com", "Olivier", "Van Aken", "picture", "", "oli12345");
            //context.Accounts.AddOrUpdate(acc);

            account = new Account("helsen.bennie@gmail.com", "Bennie", "Bax", "picture", "google-oauth2|104916923787165182658");
            account.Id = ++accountId;
            context.Accounts.AddOrUpdate(account);

            //acc = new Account("joachim@gmail.com", "Joachim", "De Schryver", "picture", "", "joa2345");
            //context.Accounts.AddOrUpdate(acc);

            account = new Account("cas.decelle@gmail.com", "Cas", "Decelle", "picture", "auth0|56d49e6d6568e621399e379c");
            account.Id = ++accountId;
            context.Accounts.AddOrUpdate(account);

            account = new Account("cas.decelle@gmail.com", "Cas", "Decelle", "picture", "google-oauth2|112196091859139010399");
            account.Id = ++accountId;
            context.Accounts.AddOrUpdate(account);

            context.SaveChanges();
            #endregion

            #region Organisations
            Organisation organisation = new Organisation("paljaskes", 1);
            organisation.Id = ++organisationId;
            context.Organisations.AddOrUpdate(organisation);

            organisation = new Organisation("nog meer paljaskes", 2);
            organisation.Id = ++organisationId;
            context.Organisations.AddOrUpdate(organisation);

            organisation = new Organisation("Limburg 4 no-life", 3);
            organisation.Id = ++organisationId;
            context.Organisations.AddOrUpdate(organisation);

            context.SaveChanges();
            #endregion

            #region ThemeSeed
            String tags = "jeugd;werken;geld";

            Theme theme = new Theme("Jongerenwerking", "Hoe laten we de jeugd terug werken", 1, 1, tags);
            theme.Id = ++themeId;
            context.Themes.AddOrUpdate(theme);

            tags = "feest;fuiven";

            theme = new Theme("Feest", "Organiseren van fuiven", 1, 1, tags);
            theme.Id = ++themeId;
            context.Themes.AddOrUpdate(theme);

            tags = "toekomst;werken;geld";

            theme = new Theme("Armoedebestrijding", "Hoe kunnen we iedereen rijk maken", 2, 2, tags);
            theme.Id = ++themeId;
            context.Themes.AddOrUpdate(theme);

            tags = "geld";

            theme = new Theme("Financien", "Hoe om gaan met geld", 3, 3, tags);
            theme.Id = ++themeId;
            context.Themes.AddOrUpdate(theme);

            tags = "geld";

            theme = new Theme("Politiek", "Politieke ideeen", 3, 3, tags);
            theme.Id = ++themeId;
            context.Themes.AddOrUpdate(theme);

            tags = "geld";

            theme = new Theme("Pesten", "Stop het pesten!", 3, 3, tags);
            theme.Id = ++themeId;
            context.Themes.AddOrUpdate(theme);



            context.SaveChanges();
            #endregion

            #region Subtheme
            Subtheme subtheme = new Subtheme("Vakantiejobs", 1, 1);
            subtheme.Id = ++subthemeId;
            context.Subthemes.AddOrUpdate(subtheme);

            subtheme = new Subtheme("Feest in jeugdhuis", 1, 2);
            subtheme.Id = ++subthemeId;
            context.Subthemes.AddOrUpdate(subtheme);

            subtheme = new Subtheme("Help de armen!", 2, 3);
            subtheme.Id = ++subthemeId;
            context.Subthemes.AddOrUpdate(subtheme);

            subtheme = new Subtheme("Democratie", 3, 5);
            subtheme.Id = ++subthemeId;
            context.Subthemes.AddOrUpdate(subtheme);

            subtheme = new Subtheme("Verkiezingen", 3, 5);
            subtheme.Id = ++subthemeId;
            context.Subthemes.AddOrUpdate(subtheme);

            subtheme = new Subtheme("Tip voor pesten tegen te gaan", 3, 6);
            subtheme.Id = ++subthemeId;
            context.Subthemes.AddOrUpdate(subtheme);

            context.SaveChanges();
            #endregion

            #region SessionSeed
            Session session = new Session(false, false, false, 3, 8, Modus.Sync, 1, 0, 1, DateTime.Now, DateTime.Now.AddDays(15));
            session.Id = ++sessionId;
            context.Sessions.AddOrUpdate(session);

            session = new Session(false, false, false, 3, 8, Modus.Sync, 1, 0, 2, DateTime.Now, DateTime.Now.AddDays(5));
            session.Id = ++sessionId;
            context.Sessions.AddOrUpdate(session);

            session = new Session(false, false, false, 3, 8, Modus.Async, 2, 0, 3, DateTime.Now, DateTime.Now.AddDays(20));
            session.Id = ++sessionId;
            context.Sessions.AddOrUpdate(session);

            session = new Session(false, false, false, 3, 8, Modus.Async, 3, 0, 4, DateTime.Now, DateTime.Now.AddDays(20));
            session.Id = ++sessionId;
            context.Sessions.AddOrUpdate(session);

            session = new Session(false, false, false, 3, 8, Modus.Async, 3, 0, 5, DateTime.Now, DateTime.Now.AddDays(20));
            session.Id = ++sessionId;
            context.Sessions.AddOrUpdate(session);

            session = new Session(false, false, false, 3, 8, Modus.Async, 3, 0, 6, DateTime.Now, DateTime.Now.AddDays(20));
            session.Id = ++sessionId;
            context.Sessions.AddOrUpdate(session);

            context.SaveChanges();
            #endregion

            #region CardSeed
            Card card = new Card(1, "testImage", 2, "Muziek");
            card.Id = ++cardId;
            context.Cards.AddOrUpdate(card);

            card = new Card(1, "testImage2", 1, "Horeca");
            card.Id = ++cardId;
            context.Cards.AddOrUpdate(card);

            card = new Card(2, "testImage", 3, "Voedselbank");
            card.Id = ++cardId;
            context.Cards.AddOrUpdate(card);

            card = new Card(3, "testImage", 4, "President");
            card.Id = ++cardId;
            context.Cards.AddOrUpdate(card);

            card = new Card(4, "testImage", 5, "Stemrondes");
            card.Id = ++cardId;
            context.Cards.AddOrUpdate(card);

            card = new Card(2, "testImage", 6, "campagnes");
            card.Id = ++cardId;
            context.Cards.AddOrUpdate(card);


            context.SaveChanges();
            #endregion

            // seed
            base.Seed(context);
        }

        private void AddOrUpdate<TEntity>(int id, TEntity entity) {
            // meh
        }
    }
}
