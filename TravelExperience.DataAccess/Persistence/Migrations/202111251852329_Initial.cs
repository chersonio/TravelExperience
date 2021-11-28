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
                        LocationID = c.Int(nullable: false),
                        MaxCapacity = c.Int(nullable: false),
                        AccommodationTypeID = c.String(),
                        Shared = c.Boolean(nullable: false),
                        Floor = c.Int(nullable: false),
                        Thumbnail = c.String(),
                    })
                .PrimaryKey(t => t.AccommodationID)
                .ForeignKey("dbo.Locations", t => t.LocationID, cascadeDelete: true)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.AccommodationUtilities",
                c => new
                    {
                        AccommodationID = c.Int(nullable: false),
                        UtilityID = c.String(nullable: false, maxLength: 128),
                        Exists = c.Boolean(nullable: false),
                        Utility_UtilitiesOfAccommodationID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.AccommodationID, t.UtilityID })
                .ForeignKey("dbo.Accommodations", t => t.AccommodationID, cascadeDelete: true)
                .ForeignKey("dbo.Utilities", t => t.Utility_UtilitiesOfAccommodationID)
                .Index(t => t.AccommodationID)
                .Index(t => t.Utility_UtilitiesOfAccommodationID);
            
            CreateTable(
                "dbo.Utilities",
                c => new
                    {
                        UtilitiesOfAccommodationID = c.String(nullable: false, maxLength: 128),
                        BeachFrontID = c.String(),
                        BeachFront = c.Boolean(nullable: false),
                        WifiID = c.String(),
                        Wifi = c.Boolean(nullable: false),
                        KitchenID = c.String(),
                        Kitchen = c.Boolean(nullable: false),
                        HotTubID = c.String(),
                        HotTub = c.Boolean(nullable: false),
                        WasherID = c.String(),
                        Washer = c.Boolean(nullable: false),
                        SelfCheckInID = c.String(),
                        SelfCheckIn = c.Boolean(nullable: false),
                        PoolID = c.String(),
                        Pool = c.Boolean(nullable: false),
                        FreeParkingID = c.String(),
                        FreeParking = c.Boolean(nullable: false),
                        DedicatedWorkspaceID = c.String(),
                        DedicatedWorkspace = c.Boolean(nullable: false),
                        SmokeAlarmID = c.String(),
                        SmokeAlarm = c.Boolean(nullable: false),
                        CarbonMonoxideAlarmID = c.String(),
                        CarbonMonoxideAlarm = c.Boolean(nullable: false),
                        HaiDryerID = c.String(),
                        HaiDryer = c.Boolean(nullable: false),
                        IronID = c.String(),
                        Iron = c.Boolean(nullable: false),
                        DryerID = c.String(),
                        Dryer = c.Boolean(nullable: false),
                        HeatingID = c.String(),
                        Heating = c.Boolean(nullable: false),
                        IndoorFireplaceID = c.String(),
                        IndoorFireplace = c.Boolean(nullable: false),
                        BeacAirConditioninghFrontID = c.String(),
                        BeacAirConditioninghFront = c.Boolean(nullable: false),
                        GymID = c.String(),
                        Gym = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UtilitiesOfAccommodationID);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Id = c.String(maxLength: 128),
                        AccommodationID = c.Int(),
                        ExperienceID = c.Int(),
                        BookingStartDate = c.DateTime(nullable: false),
                        BookingEndDate = c.DateTime(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.Accommodations", t => t.AccommodationID)
                .ForeignKey("dbo.Experiences", t => t.ExperienceID)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id)
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
                        Address = c.String(nullable: false),
                        AddressNo = c.Int(nullable: false),
                        City = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        PostalCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExperienceID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false),
                        AddressNo = c.Int(nullable: false),
                        City = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        PostalCode = c.Int(nullable: false),
                        Xcoord = c.Int(nullable: false),
                        Ycoord = c.Int(nullable: false),
                        AccommodationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        AccommodationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accommodations", t => t.AccommodationId, cascadeDelete: true)
                .Index(t => t.AccommodationId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Images", "AccommodationId", "dbo.Accommodations");
            DropForeignKey("dbo.Accommodations", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.Bookings", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bookings", "ExperienceID", "dbo.Experiences");
            DropForeignKey("dbo.Bookings", "AccommodationID", "dbo.Accommodations");
            DropForeignKey("dbo.AccommodationUtilities", "Utility_UtilitiesOfAccommodationID", "dbo.Utilities");
            DropForeignKey("dbo.AccommodationUtilities", "AccommodationID", "dbo.Accommodations");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Images", new[] { "AccommodationId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Bookings", new[] { "ExperienceID" });
            DropIndex("dbo.Bookings", new[] { "AccommodationID" });
            DropIndex("dbo.Bookings", new[] { "Id" });
            DropIndex("dbo.AccommodationUtilities", new[] { "Utility_UtilitiesOfAccommodationID" });
            DropIndex("dbo.AccommodationUtilities", new[] { "AccommodationID" });
            DropIndex("dbo.Accommodations", new[] { "LocationID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Images");
            DropTable("dbo.Locations");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Experiences");
            DropTable("dbo.Bookings");
            DropTable("dbo.Utilities");
            DropTable("dbo.AccommodationUtilities");
            DropTable("dbo.Accommodations");
        }
    }
}
