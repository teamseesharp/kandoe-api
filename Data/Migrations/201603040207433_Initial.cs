namespace Kandoe.Data.Migrations {
    using System;
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration {
        public override void Up() {
            CreateTable(
                "dbo.Accounts",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    Email = c.String(),
                    Name = c.String(),
                    Surname = c.String(),
                    Picture = c.String(),
                    Secret = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.CardReviews",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    CardId = c.Int(nullable: false),
                    Comment = c.String(),
                    ReviewerId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.ReviewerId)
                .ForeignKey("dbo.Cards", t => t.CardId)
                .Index(t => t.CardId)
                .Index(t => t.ReviewerId);

            CreateTable(
                "dbo.Cards",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    CreatorId = c.Int(nullable: false),
                    Image = c.String(),
                    SubthemeId = c.Int(nullable: false),
                    Text = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.CreatorId)
                .Index(t => t.CreatorId);

            CreateTable(
                "dbo.Sessions",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    CardCreationAllowed = c.Boolean(nullable: false),
                    CardReviewsAllowed = c.Boolean(nullable: false),
                    End = c.DateTime(nullable: false),
                    IsFinished = c.Boolean(nullable: false),
                    MaxCardsToChoose = c.Int(nullable: false),
                    MaxParticipants = c.Int(nullable: false),
                    Modus = c.Int(nullable: false),
                    OrganisationId = c.Int(nullable: false),
                    Round = c.Int(nullable: false),
                    SubthemeId = c.Int(nullable: false),
                    Start = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subthemes", t => t.SubthemeId)
                .ForeignKey("dbo.Organisations", t => t.OrganisationId)
                .Index(t => t.OrganisationId)
                .Index(t => t.SubthemeId);

            CreateTable(
                "dbo.ChatMessages",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    MessengerId = c.Int(nullable: false),
                    SessionId = c.Int(nullable: false),
                    Text = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sessions", t => t.SessionId)
                .ForeignKey("dbo.Accounts", t => t.MessengerId)
                .Index(t => t.MessengerId)
                .Index(t => t.SessionId);

            CreateTable(
                "dbo.Subthemes",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    OrganiserId = c.Int(nullable: false),
                    ThemeId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Themes", t => t.ThemeId)
                .ForeignKey("dbo.Accounts", t => t.OrganiserId)
                .Index(t => t.OrganiserId)
                .Index(t => t.ThemeId);

            CreateTable(
                "dbo.Organisations",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    OrganiserId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.OrganiserId)
                .Index(t => t.OrganiserId);

            CreateTable(
                "dbo.Themes",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Description = c.String(),
                    OrganisationId = c.Int(nullable: false),
                    OrganiserId = c.Int(nullable: false),
                    Tags = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organisations", t => t.OrganisationId)
                .ForeignKey("dbo.Accounts", t => t.OrganiserId)
                .Index(t => t.OrganisationId)
                .Index(t => t.OrganiserId);

            CreateTable(
                "dbo.SessionCards",
                c => new {
                    SessionId = c.Int(nullable: false),
                    CardId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.SessionId, t.CardId })
                .ForeignKey("dbo.Sessions", t => t.SessionId)
                .ForeignKey("dbo.Cards", t => t.CardId)
                .Index(t => t.SessionId)
                .Index(t => t.CardId);

            CreateTable(
                "dbo.SubthemeCards",
                c => new {
                    SubthemeId = c.Int(nullable: false),
                    CardId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.SubthemeId, t.CardId })
                .ForeignKey("dbo.Subthemes", t => t.SubthemeId)
                .ForeignKey("dbo.Cards", t => t.CardId)
                .Index(t => t.SubthemeId)
                .Index(t => t.CardId);

            CreateTable(
                "dbo.OrganisedSessions",
                c => new {
                    OrganiserId = c.Int(nullable: false),
                    OrganisedSessionId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.OrganiserId, t.OrganisedSessionId })
                .ForeignKey("dbo.Accounts", t => t.OrganiserId)
                .ForeignKey("dbo.Sessions", t => t.OrganisedSessionId)
                .Index(t => t.OrganiserId)
                .Index(t => t.OrganisedSessionId);

            CreateTable(
                "dbo.ParticipatingSessions",
                c => new {
                    ParticipantId = c.Int(nullable: false),
                    ParticipatingSessionId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.ParticipantId, t.ParticipatingSessionId })
                .ForeignKey("dbo.Accounts", t => t.ParticipantId)
                .ForeignKey("dbo.Sessions", t => t.ParticipatingSessionId)
                .Index(t => t.ParticipantId)
                .Index(t => t.ParticipatingSessionId);

        }

        public override void Down() {
            DropForeignKey("dbo.Themes", "OrganiserId", "dbo.Accounts");
            DropForeignKey("dbo.Subthemes", "OrganiserId", "dbo.Accounts");
            DropForeignKey("dbo.ParticipatingSessions", "ParticipatingSessionId", "dbo.Sessions");
            DropForeignKey("dbo.ParticipatingSessions", "ParticipantId", "dbo.Accounts");
            DropForeignKey("dbo.OrganisedSessions", "OrganisedSessionId", "dbo.Sessions");
            DropForeignKey("dbo.OrganisedSessions", "OrganiserId", "dbo.Accounts");
            DropForeignKey("dbo.Organisations", "OrganiserId", "dbo.Accounts");
            DropForeignKey("dbo.Themes", "OrganisationId", "dbo.Organisations");
            DropForeignKey("dbo.Subthemes", "ThemeId", "dbo.Themes");
            DropForeignKey("dbo.Sessions", "OrganisationId", "dbo.Organisations");
            DropForeignKey("dbo.ChatMessages", "MessengerId", "dbo.Accounts");
            DropForeignKey("dbo.Cards", "CreatorId", "dbo.Accounts");
            DropForeignKey("dbo.Sessions", "SubthemeId", "dbo.Subthemes");
            DropForeignKey("dbo.SubthemeCards", "CardId", "dbo.Cards");
            DropForeignKey("dbo.SubthemeCards", "SubthemeId", "dbo.Subthemes");
            DropForeignKey("dbo.ChatMessages", "SessionId", "dbo.Sessions");
            DropForeignKey("dbo.SessionCards", "CardId", "dbo.Cards");
            DropForeignKey("dbo.SessionCards", "SessionId", "dbo.Sessions");
            DropForeignKey("dbo.CardReviews", "CardId", "dbo.Cards");
            DropForeignKey("dbo.CardReviews", "ReviewerId", "dbo.Accounts");
            DropIndex("dbo.ParticipatingSessions", new[] { "ParticipatingSessionId" });
            DropIndex("dbo.ParticipatingSessions", new[] { "ParticipantId" });
            DropIndex("dbo.OrganisedSessions", new[] { "OrganisedSessionId" });
            DropIndex("dbo.OrganisedSessions", new[] { "OrganiserId" });
            DropIndex("dbo.SubthemeCards", new[] { "CardId" });
            DropIndex("dbo.SubthemeCards", new[] { "SubthemeId" });
            DropIndex("dbo.SessionCards", new[] { "CardId" });
            DropIndex("dbo.SessionCards", new[] { "SessionId" });
            DropIndex("dbo.Themes", new[] { "OrganiserId" });
            DropIndex("dbo.Themes", new[] { "OrganisationId" });
            DropIndex("dbo.Organisations", new[] { "OrganiserId" });
            DropIndex("dbo.Subthemes", new[] { "ThemeId" });
            DropIndex("dbo.Subthemes", new[] { "OrganiserId" });
            DropIndex("dbo.ChatMessages", new[] { "SessionId" });
            DropIndex("dbo.ChatMessages", new[] { "MessengerId" });
            DropIndex("dbo.Sessions", new[] { "SubthemeId" });
            DropIndex("dbo.Sessions", new[] { "OrganisationId" });
            DropIndex("dbo.Cards", new[] { "CreatorId" });
            DropIndex("dbo.CardReviews", new[] { "ReviewerId" });
            DropIndex("dbo.CardReviews", new[] { "CardId" });
            DropTable("dbo.ParticipatingSessions");
            DropTable("dbo.OrganisedSessions");
            DropTable("dbo.SubthemeCards");
            DropTable("dbo.SessionCards");
            DropTable("dbo.Themes");
            DropTable("dbo.Organisations");
            DropTable("dbo.Subthemes");
            DropTable("dbo.ChatMessages");
            DropTable("dbo.Sessions");
            DropTable("dbo.Cards");
            DropTable("dbo.CardReviews");
            DropTable("dbo.Accounts");
        }
    }
}
