using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using Kandoe.Business.Domain;

namespace Kandoe.Data.EFDB.Connection {
    [DbConfigurationType(typeof(Configuration))]
    public class Context : DbContext {

        public Context() : base("KandoeDB_EFCodeFirst") {
            Database.SetInitializer(new Initializer());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFDBContext, Migrations.Configuration>("LokaalKabaalDB_EFCodeFirst"));
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardReview> CardReviews { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Subtheme> Subthemes { get; set; }
        public DbSet<Theme> Themes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            /* Primary Keys */
            modelBuilder.Entity<Account>().HasKey(a => a.Id);
            modelBuilder.Entity<Card>().HasKey(c => c.Id);
            modelBuilder.Entity<CardReview>().HasKey(cr => cr.Id);
            modelBuilder.Entity<ChatMessage>().HasKey(cm => cm.Id);
            modelBuilder.Entity<Organisation>().HasKey(o => o.Id);
            modelBuilder.Entity<Session>().HasKey(s => s.Id);
            modelBuilder.Entity<Subtheme>().HasKey(st => st.Id);
            modelBuilder.Entity<Theme>().HasKey(t => t.Id);
        }
    }
}
