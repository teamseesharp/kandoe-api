using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using Kandoe.Business.Domain;
using Kandoe.Data.Migrations;

namespace Kandoe.Data.EFDB.Connection {
    [DbConfigurationType(typeof(Configuration))]
    public class Context : DbContext {
        /*
        public Context() : base("DB_9F4E1D_kandoedb4") {
            Database.SetInitializer();
        }
        */

        /*
        public Context() : base("KandoeDB_EFCodeFirst_Local") {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Migrations.Configuration>("KandoeDB_EFCodeFirst_Local"));
        }
        */

        /*
        public Context() : base("kandoedb") {
            Database.SetInitializer(new Initialiser());
        }
        */

        public Context() : base("KandoeDB_EFCodeFirst_Combell") {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Migrations.Configuration>("KandoeDB_EFCodeFirst_Combell"));
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<SelectionCard> SelectionCards { get; set; }
        public DbSet<SessionCard> SessionCards { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Subtheme> Subthemes { get; set; }
        public DbSet<Theme> Themes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            /* Primary Keys */
            this.SetPrimaryKeys(modelBuilder);

            /* Foreign Keys */
            this.SetForeignKeys(modelBuilder);

            /* Properties */
            this.SetOptionalProperties(modelBuilder);
            this.SetRequiredProperties(modelBuilder);
        }

        private void SetPrimaryKeys(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Account>().HasKey(a => a.Id);
            modelBuilder.Entity<ChatMessage>().HasKey(cm => cm.Id);
            modelBuilder.Entity<Organisation>().HasKey(o => o.Id);
            modelBuilder.Entity<SelectionCard>().HasKey(slc => slc.Id);
            modelBuilder.Entity<Session>().HasKey(s => s.Id);
            modelBuilder.Entity<SessionCard>().HasKey(sc => sc.Id);
            modelBuilder.Entity<Subtheme>().HasKey(st => st.Id);
            modelBuilder.Entity<Theme>().HasKey(t => t.Id);
        }

        private void SetForeignKeys(DbModelBuilder modelBuilder) {
            this.SetOneToMany(modelBuilder);
            this.SetManyToMany(modelBuilder);
        }

        private void SetOneToMany(DbModelBuilder modelBuilder) {
            // ChatMessage
            modelBuilder.Entity<Account>().HasMany(a => a.ChatMessages)
                .WithRequired()
                .HasForeignKey(cm => cm.MessengerId);
            modelBuilder.Entity<Session>().HasMany(s => s.ChatMessages)
                .WithRequired()
                .HasForeignKey(cm => cm.SessionId);

            // Organisation
            modelBuilder.Entity<Account>().HasMany(a => a.Organisations)
                .WithRequired()
                .HasForeignKey(o => o.OrganiserId);

            // SelectionCard
            modelBuilder.Entity<Subtheme>().HasMany(s => s.SelectionCards)
                .WithOptional()
                .HasForeignKey(c => c.SubthemeId);
            modelBuilder.Entity<Theme>().HasMany(s => s.SelectionCards)
                .WithRequired()
                .HasForeignKey(c => c.ThemeId);

            // Session
            modelBuilder.Entity<Organisation>().HasMany(o => o.Sessions)
                .WithRequired()
                .HasForeignKey(s => s.OrganisationId);
            modelBuilder.Entity<Subtheme>().HasMany(st => st.Sessions)
                .WithRequired()
                .HasForeignKey(s => s.SubthemeId);

            // SessionCard
            modelBuilder.Entity<Session>().HasMany(s => s.SessionCards)
                .WithRequired()
                .HasForeignKey(sc => sc.SessionId);

            // Subtheme
            modelBuilder.Entity<Account>().HasMany(a => a.Subthemes)
                .WithRequired()
                .HasForeignKey(st => st.OrganiserId);
            modelBuilder.Entity<Theme>().HasMany(t => t.Subthemes)
                .WithRequired()
                .HasForeignKey(st => st.ThemeId);

            // Theme
            modelBuilder.Entity<Account>().HasMany(a => a.Themes)
                .WithRequired()
                .HasForeignKey(t => t.OrganiserId);
            modelBuilder.Entity<Organisation>().HasMany(o => o.Themes)
                .WithRequired()
                .HasForeignKey(t => t.OrganisationId);
        }
        private void SetManyToMany(DbModelBuilder modelBuilder) {
            // Accounts 1..n - 0..n Sessions (Organising)
            modelBuilder.Entity<Account>()
                .HasMany(a => a.OrganisedSessions)
                .WithMany(ms => ms.Organisers)
                .Map(t => t.MapLeftKey("OrganiserId")
                    .MapRightKey("OrganisedSessionId")
                    .ToTable("OrganisedSessions"));

            // Accounts 1..n - 0..n Sessions (Participating)
            modelBuilder.Entity<Account>()
                .HasMany(a => a.ParticipatingSessions)
                .WithMany(ms => ms.Participants)
                .Map(t => t.MapLeftKey("ParticipantId")
                    .MapRightKey("ParticipatingSessionId")
                    .ToTable("ParticipatingSessions"));
        }

        private void SetOptionalProperties(DbModelBuilder modelBuilder) {
            // Account
            modelBuilder.Entity<Account>()
                .Property(a => a.Picture)
                .IsOptional();

            // SelectionCard
            modelBuilder.Entity<SelectionCard>()
                .Property(slc => slc.Image)
                .IsOptional();
            modelBuilder.Entity<SelectionCard>()
                .Property(slc => slc.SubthemeId)
                .IsOptional();

            // SessionCard
            modelBuilder.Entity<SessionCard>()
                .Property(slc => slc.Image)
                .IsOptional();

            // Theme
            modelBuilder.Entity<Theme>()
                .Property(t => t.Tags)
                .IsOptional();
        }

        private void SetRequiredProperties(DbModelBuilder modelBuilder) {
            // Account
            modelBuilder.Entity<Account>()
                .Property(a => a.Email)
                .IsRequired();
            modelBuilder.Entity<Account>()
                .Property(a => a.Name)
                .IsRequired();
            modelBuilder.Entity<Account>()
                .Property(a => a.Secret)
                .IsRequired();
            modelBuilder.Entity<Account>()
                .Property(a => a.Surname)
                .IsRequired();

            // ChatMessage
            modelBuilder.Entity<ChatMessage>()
                .Property(cm => cm.Text)
                .IsRequired();
            modelBuilder.Entity<ChatMessage>()
                .Property(cm => cm.Timestamp)
                .IsRequired();

            // Organisation
            modelBuilder.Entity<Organisation>()
                .Property(o => o.Name)
                .IsRequired();

            // SelectionCard
            modelBuilder.Entity<SelectionCard>()
                .Property(slc => slc.Text)
                .IsRequired();

            // Session
            modelBuilder.Entity<Session>()
                .Property(s => s.CardCreationAllowed)
                .IsRequired();
            modelBuilder.Entity<Session>()
                .Property(s => s.CardReviewsAllowed)
                .IsRequired();
            modelBuilder.Entity<Session>()
                .Property(s => s.CurrentPlayerIndex)
                .IsRequired();
            modelBuilder.Entity<Session>()
                .Property(s => s.End)
                .IsRequired();
            modelBuilder.Entity<Session>()
                .Property(s => s.IsFinished)
                .IsRequired();
            modelBuilder.Entity<Session>()
                .Property(s => s.MaxCardsToChoose)
                .IsRequired();
            modelBuilder.Entity<Session>()
                .Property(s => s.Start)
                .IsRequired();

            // SessionCard
            modelBuilder.Entity<SessionCard>()
                .Property(slc => slc.SessionLevel)
                .IsRequired();
            modelBuilder.Entity<SessionCard>()
                .Property(slc => slc.Text)
                .IsRequired();

            // Subtheme
            modelBuilder.Entity<Subtheme>()
                .Property(st => st.Name)
                .IsRequired();

            // Theme
            modelBuilder.Entity<Theme>()
                .Property(t => t.Description)
                .IsRequired();
            modelBuilder.Entity<Theme>()
                .Property(t => t.Name)
                .IsRequired();
        }
    }
}
