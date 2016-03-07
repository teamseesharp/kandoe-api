﻿using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;

using Kandoe.Business.Domain;

namespace Kandoe.Data.EFDB.Connection {
    public class Initialiser : DropCreateDatabaseAlways<Context> {
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

            organisation = new Organisation("nog meer paljaskes", 1);
            organisation.Id = ++organisationId;
            context.Organisations.AddOrUpdate(organisation);

            organisation = new Organisation("Limburg 4 no-life", 1);
            organisation.Id = ++organisationId;
            context.Organisations.AddOrUpdate(organisation);

            context.SaveChanges();
            #endregion

            #region ThemeSeed
            String tags = "Jeugd;Werken;Geld";

            Theme theme = new Theme("Jongerenwerking", "Hoe laten we de jeugd terug werken", 1, 1, tags);
            theme.Id = ++themeId;
            context.Themes.AddOrUpdate(theme);

            tags = "Toekomst;Werken;Geld";

            theme = new Theme("Armoedebestrijding", "Hoe kunnen we iedereen rijk maken", 1, 1, tags);
            theme.Id = ++themeId;
            context.Themes.AddOrUpdate(theme);

            context.SaveChanges();
            #endregion

            #region Subtheme
            Subtheme subtheme = new Subtheme("gayy", 1, 1);
            subtheme.Id = ++subthemeId;
            context.Subthemes.AddOrUpdate(subtheme);

            subtheme = new Subtheme("Ik ben sexy", 1, 2);
            subtheme.Id = ++subthemeId;
            context.Subthemes.AddOrUpdate(subtheme);

            subtheme = new Subtheme("Ik ben sexy2", 1, 2);
            subtheme.Id = ++subthemeId;
            context.Subthemes.AddOrUpdate(subtheme);

            context.SaveChanges();
            #endregion

            #region SessionSeed
            Session session = new Session(false, false, false, 3, 8, Modus.Sync, 1, 1, 1, DateTime.Now, DateTime.Now.AddDays(15));
            session.Id = ++sessionId;
            context.Sessions.AddOrUpdate(session);

            session = new Session(false, false, false, 3, 8, Modus.Sync, 2, 1, 2, DateTime.Now, DateTime.Now.AddDays(5));
            session.Id = ++sessionId;
            context.Sessions.AddOrUpdate(session);

            session = new Session(false, false, false, 3, 8, Modus.Async, 3, 1, 3, DateTime.Now, DateTime.Now.AddDays(20));
            session.Id = ++sessionId;
            context.Sessions.AddOrUpdate(session);

            context.SaveChanges();
            #endregion

            #region CardSeed
            Card card = new Card(1, "testImage", 2, "Armoede");
            card.Id = ++cardId;
            context.Cards.AddOrUpdate(card);

            card = new Card(1, "testImage2", 1, "Jeugdhuis");
            card.Id = ++cardId;
            context.Cards.AddOrUpdate(card);

            card = new Card(1, "testImage", 3, "Werkloosheid");
            card.Id = ++cardId;
            context.Cards.AddOrUpdate(card);

            context.SaveChanges();
            #endregion

            // seed
            base.Seed(context);
        }
    }
}
