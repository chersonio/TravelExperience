namespace TravelExperience.DataAccess.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPricePerNightAtAccommmodation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accommodations", "PricePerNight", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accommodations", "PricePerNight");
        }
    }
}
