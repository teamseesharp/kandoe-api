namespace Kandoe.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Surname", c => c.String());
            AddColumn("dbo.Accounts", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "Password");
            DropColumn("dbo.Accounts", "Surname");
        }
    }
}
