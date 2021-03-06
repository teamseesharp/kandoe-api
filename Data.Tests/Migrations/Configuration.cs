using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

using Kandoe.Business.Domain;
using Kandoe.Data.Tests.Fakes;

namespace Kandoe.Data.Tests.Migrations {
    internal sealed class Configuration : DbMigrationsConfiguration<FakeContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(FakeContext context) {
            int accountId = 0;
            int chatmessageId = 0;
            int sessionId = 0;
            int themeId = 0;
            int subthemeId = 0;
            int selectionCardId = 0;
            int sessionCardId = 0;
            int organisationId = 0;

            #region AccountSeed
            Account account = new Account("thomastvd@gmail.com", "Thomas", "Van Deun", "http://i.imgur.com/SNoEbli.png", "auth0|56d4591317aca91f1aff5dfb");
            account.Id = ++accountId;
            context.Accounts.AddOrUpdate(account);

            //acc = new Account("michelle@gmail.com", "Michelle", "Beckers", "picture", "", "michelle13245");
            //context.Accounts.AddOrUpdate(acc);

            //acc = new Account("olivier@gmail.com", "Olivier", "Van Aken", "picture", "", "oli12345");
            //context.Accounts.AddOrUpdate(acc);

            account = new Account("helsen.bennie@gmail.com", "Bennie", "Bax", "http://i.imgur.com/SNoEbli.png", "google-oauth2|104916923787165182658");
            account.Id = ++accountId;
            context.Accounts.AddOrUpdate(account);

            //acc = new Account("joachim@gmail.com", "Joachim", "De Schryver", "picture", "", "joa2345");
            //context.Accounts.AddOrUpdate(acc);

            account = new Account("cas.decelle@gmail.com", "Cas", "Decelle", "http://i.imgur.com/SNoEbli.png", "auth0|56d49e6d6568e621399e379c");
            account.Id = ++accountId;
            context.Accounts.AddOrUpdate(account);

            account = new Account("cas.decelle@gmail.com", "Cas", "Decelle", "http://i.imgur.com/SNoEbli.png", "google-oauth2|112196091859139010399");
            account.Id = ++accountId;
            context.Accounts.AddOrUpdate(account);

            account = new Account("test@test.be", "test", "hihi", "http://i.imgur.com/SNoEbli.png", "auth0|56d32ffb17aca91f1aff4493");
            account.Id = ++accountId;
            context.Accounts.AddOrUpdate(account);


            context.SaveChanges();
            #endregion

            #region Organisations
            Organisation organisation = new Organisation("Jeugd", 1);
            organisation.Id = ++organisationId;
            context.Organisations.AddOrUpdate(organisation);

            organisation = new Organisation("OCMW", 2);
            organisation.Id = ++organisationId;
            context.Organisations.AddOrUpdate(organisation);

            organisation = new Organisation("Overheid", 3);
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

            subtheme = new Subtheme("Speelplein", 1, 1);
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
            Session session = new Session(true, 1, "session1", true, 3, 8, 1, 0, 1, DateTime.Now, DateTime.Today);
            session.Id = ++sessionId;
            context.Sessions.AddOrUpdate(session);

            session = new Session(true, 1, "session2", false, 3, 8, 1, 0, 2, DateTime.Now, DateTime.Today);
            session.Id = ++sessionId;
            context.Sessions.AddOrUpdate(session);

            session = new Session(true, 1, "session3", false, 3, 8, 1, 0, 2, DateTime.Now.AddDays(2), DateTime.Today);
            session.Id = ++sessionId;
            context.Sessions.AddOrUpdate(session);

            session = new Session(false, 2, "session4", true, 3, 8, 1, 0, 3, DateTime.Now, DateTime.Today);
            session.Id = ++sessionId;
            context.Sessions.AddOrUpdate(session);

            session = new Session(false, 3, "session5", false, 3, 8, 2, 0, 4, DateTime.Now.AddDays(10), DateTime.Today);
            session.Id = ++sessionId;
            context.Sessions.AddOrUpdate(session);

            session = new Session(false, 3, "session6", false, 3, 8, 3, 0, 7, DateTime.Now.AddDays(8), DateTime.Today);
            session.Id = ++sessionId;
            context.Sessions.AddOrUpdate(session);

            session = new Session(false, 3, "session7", false, 3, 8, 3, 0, 7, DateTime.Now, DateTime.Today);
            session.Id = ++sessionId;
            context.Sessions.AddOrUpdate(session);

            session = new Session(true, 1, "session8", false, 3, 8, 3, 0, 7, DateTime.Now, DateTime.Today);
            session.Id = ++sessionId;
            context.Sessions.AddOrUpdate(session);

            //bool cardCreationAllowed,int currentPlayerIndex, bool isFinished, int maxCardsToChoose, int maxParticipants, Modus modus, int organisationId, int round, int subthemeId, DateTime start, DateTime end
            session = new Session(true, 3, "session9", false, 3, 6, 3, 0, 7, DateTime.Now.AddDays(-4), DateTime.Today.AddDays(-1));
            session.Id = ++sessionId;
            context.Sessions.AddOrUpdate(session);

            context.SaveChanges();
            #endregion

            #region ChatmsgSeed
            //SESSION 1
            ChatMessage chatmessage = new ChatMessage(1, 1, "hoi", DateTime.Today.AddDays(-2));
            chatmessage.Id = ++chatmessageId;
            context.ChatMessages.AddOrUpdate(chatmessage);

            chatmessage = new ChatMessage(2, 1, "hey", DateTime.Today.AddDays(-1));
            chatmessage.Id = ++chatmessageId;
            context.ChatMessages.AddOrUpdate(chatmessage);

            chatmessage = new ChatMessage(1, 1, "hihi", DateTime.Today.AddDays(-1));
            chatmessage.Id = ++chatmessageId;
            context.ChatMessages.AddOrUpdate(chatmessage);

            //SESSION 2
            chatmessage = new ChatMessage(1, 2, "Dit", DateTime.Now);
            chatmessage.Id = ++chatmessageId;
            context.ChatMessages.AddOrUpdate(chatmessage);

            chatmessage = new ChatMessage(2, 2, "is", DateTime.Now);
            chatmessage.Id = ++chatmessageId;
            context.ChatMessages.AddOrUpdate(chatmessage);

            chatmessage = new ChatMessage(4, 2, "een", DateTime.Now);
            chatmessage.Id = ++chatmessageId;
            context.ChatMessages.AddOrUpdate(chatmessage);

            chatmessage = new ChatMessage(5, 2, "chatmessage", DateTime.Now);
            chatmessage.Id = ++chatmessageId;
            context.ChatMessages.AddOrUpdate(chatmessage);

            //SESSION 4
            chatmessage = new ChatMessage(1, 4, "Kandoe is top !", DateTime.Now);
            chatmessage.Id = ++chatmessageId;
            context.ChatMessages.AddOrUpdate(chatmessage);

            chatmessage = new ChatMessage(2, 4, "joepiee", DateTime.Now);
            chatmessage.Id = ++chatmessageId;
            context.ChatMessages.AddOrUpdate(chatmessage);

            chatmessage = new ChatMessage(3, 4, "hoi allemaal", DateTime.Now);
            chatmessage.Id = ++chatmessageId;
            context.ChatMessages.AddOrUpdate(chatmessage);

            //SESSION 5
            chatmessage = new ChatMessage(1, 5, "Testje", DateTime.Now);
            chatmessage.Id = ++chatmessageId;
            context.ChatMessages.AddOrUpdate(chatmessage);

            chatmessage = new ChatMessage(5, 5, "lalalallaa", DateTime.Now);
            chatmessage.Id = ++chatmessageId;
            context.ChatMessages.AddOrUpdate(chatmessage);

            context.SaveChanges();

            #endregion

            #region SelectionCardSeed
            //THEMA 1
            SelectionCard selectionCard = new SelectionCard("testImage", "Toneel", 1);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            //SUBTHEMA 1
            selectionCard = new SelectionCard("testImage", "Flexibele uren", 1, 1);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Toffe collega's ", 1, 1);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Minumumloon", 1, 1);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Uren/week", 1, 1);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Zomerjob", 1, 1);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            //SUBTHEMA 2
            selectionCard = new SelectionCard("testImage", "Opvang", 1, 2);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Sport", 1, 2);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Vrijwilligerswerk", 1, 2);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Kinderen < 12", 1, 2);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Kinderen > 12", 1, 2);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Locatie", 1, 2);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            //THEMA 2
            selectionCard = new SelectionCard("testImage", "Goede locatie", 2);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Grote capaciteit", 2);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            //SUBTHEMA 3
            selectionCard = new SelectionCard("testImage", "Vestiare", 2, 3);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Cocktailbar", 2, 3);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Goede muziekinstallatie", 2, 3);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Lichten", 2, 3);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Minimumleeftijd", 1, 3);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Einduur", 1, 3);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            //THEMA 3
            //SUBTHEMA 4
            selectionCard = new SelectionCard("testImage", "Voedselbank", 3, 4);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Kledingverzamelactie", 3, 4);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Opvangcentra", 3, 4);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Dekens uitdelen", 3, 4);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Geld geven", 3, 4);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            //THEMA 4
            selectionCard = new SelectionCard("testImage", "Begroting", 4);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Kamer van koophandel", 4);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            //THEMA 5
            selectionCard = new SelectionCard("testImage", "Debat", 5);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Eerste minister", 5);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);


            //SUBTHEMA 5
            selectionCard = new SelectionCard("testImage", "President", 5, 5);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Koning", 5, 5);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            //SUBTHEMA 6
            selectionCard = new SelectionCard("testImage", "Groen", 5, 6);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "SPA", 5, 6);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Vlaams belang", 5, 6);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "CD&V", 5, 6);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "MR", 5, 6);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);



            //THEMA 6
            selectionCard = new SelectionCard("testImage", "Pesters", 6);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Slachtoffers", 6);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            //SUBTHEMA 7
            selectionCard = new SelectionCard("testImage", "Campagnes", 6, 7);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Anti-pesten helpnummer", 6, 7);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Anonieme helpchat", 6, 7);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Website", 6, 7);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);

            selectionCard = new SelectionCard("testImage", "Gesprekken op school", 6, 7);
            selectionCard.Id = ++selectionCardId;
            context.SelectionCards.AddOrUpdate(selectionCard);


            context.SaveChanges();
            #endregion

            #region SesssionCardSeed
            //Cards SESSION 1
            SessionCard sessionCard = new SessionCard("testImage", 1, "Flexibele uren");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            sessionCard = new SessionCard("testImage", 1, "Toffe collega's ");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            sessionCard = new SessionCard("testImage", 1, "Uren/week");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            sessionCard = new SessionCard("testImage", 1, "Zomerjob");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            sessionCard = new SessionCard("testImage", 1, "Horeca");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            //Cards SESSION 2
            sessionCard = new SessionCard("testImage", 2, "Opvang");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            sessionCard = new SessionCard("testImage", 2, "Vrijwilligerswerk");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            sessionCard = new SessionCard("testImage", 2, "Kinderen < 12");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            sessionCard = new SessionCard("testImage", 2, "Kinderen > 12");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            sessionCard = new SessionCard("testImage", 2, "Locatie");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            //Cards SESSION 3
            sessionCard = new SessionCard("testImage", 3, "Opvang");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            sessionCard = new SessionCard("testImage", 3, "Kinderen < 12");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            sessionCard = new SessionCard("testImage", 3, "Kinderen > 12");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);


            //Cards SESSION 4
            sessionCard = new SessionCard("testImage", 4, "Vestiare");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            sessionCard = new SessionCard("testImage", 4, "Cocktailbar");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            sessionCard = new SessionCard("testImage", 4, "Goede muziekinstallatie");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            sessionCard = new SessionCard("testImage", 4, "Lichten");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            //Cards SESSION 5
            sessionCard = new SessionCard("testImage", 5, "Voedselbank");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            sessionCard = new SessionCard("testImage", 5, "Opvangcentra");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            sessionCard = new SessionCard("testImage", 5, "Kledingverzamelactie");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            //Cards SESSION 6
            sessionCard = new SessionCard("testImage", 6, "Campagnes");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            sessionCard = new SessionCard("testImage", 6, "Anonieme helpchat");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            sessionCard = new SessionCard("testImage", 6, "Anti-pesten helpnummer");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            sessionCard = new SessionCard("testImage", 6, "Website");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            //Cards SESSION 7
            sessionCard = new SessionCard("testImage", 7, "Gesprekken op school");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            sessionCard = new SessionCard("testImage", 7, "Anti-pesten helpnummer");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            sessionCard = new SessionCard("testImage", 7, "Campagnes");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            sessionCard = new SessionCard("testImage", 7, "Website");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            sessionCard = new SessionCard("testImage", 7, "Anonieme helpchat");
            sessionCard.Id = ++sessionCardId;
            context.SessionCards.AddOrUpdate(sessionCard);

            context.SaveChanges();
            #endregion

            // seed
            base.Seed(context);
        }
    }
}
