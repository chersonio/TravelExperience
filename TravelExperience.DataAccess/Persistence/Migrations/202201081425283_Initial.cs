namespace TravelExperience.DataAccess.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accommodations", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.Utilities", "AccommodationID", "dbo.Accommodations");
            AddForeignKey("dbo.Accommodations", "LocationID", "dbo.Locations", "LocationID", cascadeDelete: true);
            AddForeignKey("dbo.Utilities", "AccommodationID", "dbo.Accommodations", "AccommodationID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Utilities", "AccommodationID", "dbo.Accommodations");
            DropForeignKey("dbo.Accommodations", "LocationID", "dbo.Locations");
            AddForeignKey("dbo.Utilities", "AccommodationID", "dbo.Accommodations", "AccommodationID");
            AddForeignKey("dbo.Accommodations", "LocationID", "dbo.Locations", "LocationID");
        }
    }
}
