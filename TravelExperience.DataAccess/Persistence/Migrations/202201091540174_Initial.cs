namespace TravelExperience.DataAccess.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accommodations", "AvailableFromDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Accommodations", "AvailableToDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Accommodations", "CreationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accommodations", "CreationDate");
            DropColumn("dbo.Accommodations", "AvailableToDate");
            DropColumn("dbo.Accommodations", "AvailableFromDate");
        }
    }
}
