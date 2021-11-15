namespace TravelExperience.DataAccess.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accommodations",
                c => new
                    {
                        AccommodationID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 250),
                        AccommodationType = c.Int(nullable: false),
                        MaxCapacity = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        AvailableDates = c.DateTime(nullable: false),
                        BookedDates = c.DateTime(nullable: false),
                        Shared = c.Boolean(nullable: false),
                        Address = c.String(nullable: false),
                        AddressNo = c.Int(nullable: false),
                        City = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        PostalCode = c.Int(nullable: false),
                        Floor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccommodationID);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HostID = c.Int(nullable: false),
                        TravelerID = c.Int(nullable: false),
                        AccommodationID = c.Int(nullable: false),
                        ExperienceID = c.Int(nullable: false),
                        BookingStartDate = c.DateTime(nullable: false),
                        BookingEndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.Accommodations", t => t.AccommodationID, cascadeDelete: true)
                .ForeignKey("dbo.Experiences", t => t.ExperienceID, cascadeDelete: true)
                .ForeignKey("dbo.Travelers", t => t.TravelerID, cascadeDelete: true)
                .Index(t => t.TravelerID)
                .Index(t => t.AccommodationID)
                .Index(t => t.ExperienceID);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        ExperienceID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 250),
                        MaxCapacity = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        AvailableDates = c.DateTime(nullable: false),
                        BookedDates = c.DateTime(nullable: false),
                        Shared = c.Boolean(nullable: false),
                        Address = c.String(nullable: false),
                        AddressNo = c.Int(nullable: false),
                        City = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        PostalCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExperienceID);
            
            CreateTable(
                "dbo.Travelers",
                c => new
                    {
                        TravelerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        VAT = c.String(nullable: false, maxLength: 12),
                        IdentificationNo = c.String(nullable: false, maxLength: 10),
                        Address = c.String(),
                        AddressNo = c.Int(nullable: false),
                        City = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        PostalCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TravelerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "TravelerID", "dbo.Travelers");
            DropForeignKey("dbo.Bookings", "ExperienceID", "dbo.Experiences");
            DropForeignKey("dbo.Bookings", "AccommodationID", "dbo.Accommodations");
            DropIndex("dbo.Bookings", new[] { "ExperienceID" });
            DropIndex("dbo.Bookings", new[] { "AccommodationID" });
            DropIndex("dbo.Bookings", new[] { "TravelerID" });
            DropTable("dbo.Travelers");
            DropTable("dbo.Experiences");
            DropTable("dbo.Bookings");
            DropTable("dbo.Accommodations");
        }
    }
}
