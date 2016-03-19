namespace Kandoe.Data.Tests.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Picture = c.String(),
                        Secret = c.String(nullable: false),
                        Session_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sessions", t => t.Session_Id)
                .Index(t => t.Session_Id);
            
            CreateTable(
                "dbo.ChatMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessengerId = c.Int(nullable: false),
                        SessionId = c.Int(nullable: false),
                        SnapshotId = c.Int(),
                        Text = c.String(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.MessengerId)
                .ForeignKey("dbo.Sessions", t => t.SessionId)
                .Index(t => t.MessengerId)
                .Index(t => t.SessionId);
            
            CreateTable(
                "dbo.Organisations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        OrganiserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.OrganiserId)
                .Index(t => t.OrganiserId);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardCreationAllowed = c.Boolean(nullable: false),
                        CurrentPlayerIndex = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        End = c.DateTime(nullable: false),
                        IsFinished = c.Boolean(nullable: false),
                        MaxCardsToChoose = c.Int(nullable: false),
                        MaxParticipants = c.Int(nullable: false),
                        OrganisationId = c.Int(nullable: false),
                        Round = c.Int(nullable: false),
                        SubthemeId = c.Int(nullable: false),
                        Start = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organisations", t => t.OrganisationId)
                .ForeignKey("dbo.Subthemes", t => t.SubthemeId)
                .Index(t => t.OrganisationId)
                .Index(t => t.SubthemeId);
            
            CreateTable(
                "dbo.SessionCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        SessionId = c.Int(nullable: false),
                        SessionLevel = c.Int(nullable: false),
                        Text = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sessions", t => t.SessionId)
                .Index(t => t.SessionId);
            
            CreateTable(
                "dbo.Themes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
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
                "dbo.SelectionCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        Text = c.String(nullable: false),
                        ThemeId = c.Int(nullable: false),
                        SubthemeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Themes", t => t.ThemeId)
                .ForeignKey("dbo.Subthemes", t => t.SubthemeId)
                .Index(t => t.ThemeId)
                .Index(t => t.SubthemeId);
            
            CreateTable(
                "dbo.Subthemes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        OrganiserId = c.Int(nullable: false),
                        ThemeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Themes", t => t.ThemeId)
                .ForeignKey("dbo.Accounts", t => t.OrganiserId)
                .Index(t => t.OrganiserId)
                .Index(t => t.ThemeId);
            
            CreateTable(
                "dbo.OrganisedSessions",
                c => new
                    {
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
                c => new
                    {
                        ParticipantId = c.Int(nullable: false),
                        ParticipatingSessionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ParticipantId, t.ParticipatingSessionId })
                .ForeignKey("dbo.Accounts", t => t.ParticipantId)
                .ForeignKey("dbo.Sessions", t => t.ParticipatingSessionId)
                .Index(t => t.ParticipantId)
                .Index(t => t.ParticipatingSessionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Themes", "OrganiserId", "dbo.Accounts");
            DropForeignKey("dbo.Subthemes", "OrganiserId", "dbo.Accounts");
            DropForeignKey("dbo.ParticipatingSessions", "ParticipatingSessionId", "dbo.Sessions");
            DropForeignKey("dbo.ParticipatingSessions", "ParticipantId", "dbo.Accounts");
            DropForeignKey("dbo.OrganisedSessions", "OrganisedSessionId", "dbo.Sessions");
            DropForeignKey("dbo.OrganisedSessions", "OrganiserId", "dbo.Accounts");
            DropForeignKey("dbo.Organisations", "OrganiserId", "dbo.Accounts");
            DropForeignKey("dbo.Themes", "OrganisationId", "dbo.Organisations");
            DropForeignKey("dbo.Subthemes", "ThemeId", "dbo.Themes");
            DropForeignKey("dbo.Sessions", "SubthemeId", "dbo.Subthemes");
            DropForeignKey("dbo.SelectionCards", "SubthemeId", "dbo.Subthemes");
            DropForeignKey("dbo.SelectionCards", "ThemeId", "dbo.Themes");
            DropForeignKey("dbo.Sessions", "OrganisationId", "dbo.Organisations");
            DropForeignKey("dbo.SessionCards", "SessionId", "dbo.Sessions");
            DropForeignKey("dbo.Accounts", "Session_Id", "dbo.Sessions");
            DropForeignKey("dbo.ChatMessages", "SessionId", "dbo.Sessions");
            DropForeignKey("dbo.ChatMessages", "MessengerId", "dbo.Accounts");
            DropIndex("dbo.ParticipatingSessions", new[] { "ParticipatingSessionId" });
            DropIndex("dbo.ParticipatingSessions", new[] { "ParticipantId" });
            DropIndex("dbo.OrganisedSessions", new[] { "OrganisedSessionId" });
            DropIndex("dbo.OrganisedSessions", new[] { "OrganiserId" });
            DropIndex("dbo.Subthemes", new[] { "ThemeId" });
            DropIndex("dbo.Subthemes", new[] { "OrganiserId" });
            DropIndex("dbo.SelectionCards", new[] { "SubthemeId" });
            DropIndex("dbo.SelectionCards", new[] { "ThemeId" });
            DropIndex("dbo.Themes", new[] { "OrganiserId" });
            DropIndex("dbo.Themes", new[] { "OrganisationId" });
            DropIndex("dbo.SessionCards", new[] { "SessionId" });
            DropIndex("dbo.Sessions", new[] { "SubthemeId" });
            DropIndex("dbo.Sessions", new[] { "OrganisationId" });
            DropIndex("dbo.Organisations", new[] { "OrganiserId" });
            DropIndex("dbo.ChatMessages", new[] { "SessionId" });
            DropIndex("dbo.ChatMessages", new[] { "MessengerId" });
            DropIndex("dbo.Accounts", new[] { "Session_Id" });
            DropTable("dbo.ParticipatingSessions");
            DropTable("dbo.OrganisedSessions");
            DropTable("dbo.Subthemes");
            DropTable("dbo.SelectionCards");
            DropTable("dbo.Themes");
            DropTable("dbo.SessionCards");
            DropTable("dbo.Sessions");
            DropTable("dbo.Organisations");
            DropTable("dbo.ChatMessages");
            DropTable("dbo.Accounts");
        }
    }
}
