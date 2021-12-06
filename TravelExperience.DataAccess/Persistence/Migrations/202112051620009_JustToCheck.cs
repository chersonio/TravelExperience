namespace TravelExperience.DataAccess.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JustToCheck : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Utilities", "Value");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Utilities", "Value", c => c.Boolean(nullable: false));
        }
    }
}
