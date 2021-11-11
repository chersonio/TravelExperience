namespace TravelExperience.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewInitial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accommodations", "Traveler_TravelerID", "dbo.Travelers");
            DropForeignKey("dbo.Experiences", "Traveler_TravelerID1", "dbo.Travelers");
            DropIndex("dbo.Accommodations", new[] { "Traveler_TravelerID1" });
            DropIndex("dbo.Accommodations", new[] { "Traveler_TravelerID2" });
            DropIndex("dbo.Experiences", new[] { "Traveler_TravelerID2" });
            DropColumn("dbo.Accommodations", "Traveler_TravelerID");
            DropColumn("dbo.Experiences", "Traveler_TravelerID1");
            RenameColumn(table: "dbo.Accommodations", name: "Traveler_TravelerID2", newName: "Traveler_TravelerID1");
            RenameColumn(table: "dbo.Accommodations", name: "Traveler_TravelerID1", newName: "Traveler_TravelerID");
            RenameColumn(table: "dbo.Experiences", name: "Traveler_TravelerID2", newName: "Traveler_TravelerID1");
            AddColumn("dbo.Accommodations", "IsBooking", c => c.Boolean(nullable: false));
            AddColumn("dbo.Experiences", "IsBooking", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Accommodations", "Traveler_TravelerID1", c => c.Int(nullable: false));
            CreateIndex("dbo.Accommodations", "Traveler_TravelerID1");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Accommodations", new[] { "Traveler_TravelerID1" });
            AlterColumn("dbo.Accommodations", "Traveler_TravelerID1", c => c.Int());
            DropColumn("dbo.Experiences", "IsBooking");
            DropColumn("dbo.Accommodations", "IsBooking");
            RenameColumn(table: "dbo.Experiences", name: "Traveler_TravelerID1", newName: "Traveler_TravelerID2");
            RenameColumn(table: "dbo.Accommodations", name: "Traveler_TravelerID", newName: "Traveler_TravelerID1");
            RenameColumn(table: "dbo.Accommodations", name: "Traveler_TravelerID1", newName: "Traveler_TravelerID2");
            AddColumn("dbo.Experiences", "Traveler_TravelerID1", c => c.Int());
            AddColumn("dbo.Accommodations", "Traveler_TravelerID", c => c.Int());
            CreateIndex("dbo.Experiences", "Traveler_TravelerID2");
            CreateIndex("dbo.Accommodations", "Traveler_TravelerID2");
            CreateIndex("dbo.Accommodations", "Traveler_TravelerID1");
            AddForeignKey("dbo.Experiences", "Traveler_TravelerID1", "dbo.Travelers", "TravelerID");
            AddForeignKey("dbo.Accommodations", "Traveler_TravelerID", "dbo.Travelers", "TravelerID");
        }
    }
}
