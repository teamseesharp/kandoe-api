using System.Data.Entity.Migrations;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;
using System;
using System.Collections;

namespace Kandoe.Data.Migrations {
    public sealed class Configuration : DbMigrationsConfiguration<Context> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context) {


            #region UserSeed
            Account acc = new Account("thomas@gmail.com", "Thomas Van Deun", "", "abcde12345");
            context.Accounts.AddOrUpdate(acc);

             acc = new Account("michelle@gmail.com", "Michelle Beckers", "", "michelle13245");
            context.Accounts.AddOrUpdate(acc);

             acc = new Account("olivier@gmail.com", "Olivier Van Aken", "", "oli12345");
            context.Accounts.AddOrUpdate(acc);

             acc = new Account("bennie@gmail.com", "Bennie Bax", "", "bennie12345");
            context.Accounts.AddOrUpdate(acc);

             acc = new Account("joachim@gmail.com", "Joachim De SchryverDateTime.Now", "", "joa2345");
            context.Accounts.AddOrUpdate(acc);

             acc = new Account("cas@gmail.com", "Cas Decelle", "", "cas12345");
            context.Accounts.AddOrUpdate(acc);

            context.SaveChanges();

            #endregion

            #region SessionSeed
            
            Session session = new Session(Modus.Sync, DateTime.Now, DateTime.Now.AddDays(15));
            context.Sessions.AddOrUpdate(session);

             session = new Session(Modus.Sync, DateTime.Now, DateTime.Now.AddDays(5));
            context.Sessions.AddOrUpdate(session);

            session = new Session(Modus.Async, DateTime.Now, DateTime.Now.AddDays(20));
            context.Sessions.AddOrUpdate(session);

            context.SaveChanges();

            #endregion

            #region ThemeSeed
            ArrayList list = new ArrayList();
            list.Add("Jeugd");
            list.Add("Werken");
            list.Add("Geld");

            Theme theme = new Theme("Jongerenwerking", "Hoe laten we de jeugd terug werken", 1, list);
            context.Themes.AddOrUpdate(theme);

            list = new ArrayList();
            list.Add("Toekomst");
            list.Add("Werken");
            list.Add("Geld");

            theme = new Theme("Armoedebestrijding", "Hoe kunnen we iedereen rijk maken", 1, list);
            context.Themes.AddOrUpdate(theme);

            context.SaveChanges();

            #endregion

            #region CardSeed


            Card card = new Card("testImage", 0, "Armoede");
           
            context.Cards.AddOrUpdate(card);

            card = new Card("testImage2", 1, "Jeugdhuis");
           
            context.Cards.AddOrUpdate(card);

            card = new Card("testImage", 0, "Werkloosheid");
            
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
