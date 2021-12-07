namespace TravelExperience.DataAccess.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExistsToAccommodationUtilities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccommodationUtilities", "Exists", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccommodationUtilities", "Exists");
        }
    }
}
