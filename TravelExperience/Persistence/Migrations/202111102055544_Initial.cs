namespace TravelExperience.Persistence.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accommodations",
                c => new
                {
                    PlacementID = c.Int(nullable: false, identity: true),
                    HostID = c.Int(nullable: false),
                    Title = c.String(nullable: false, maxLength: 50),
                    AvailableDates = c.DateTime(nullable: false),
                    BookedDates = c.DateTime(nullable: false),
                    CreationDate = c.DateTime(nullable: false),
                    Description = c.String(nullable: false, maxLength: 250),
                    Shared = c.Boolean(nullable: false),
                    Price = c.Double(nullable: false),
                    LocationID = c.Int(nullable: false),
                    MaxCapacity = c.Int(nullable: false),
                    Host_ID = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.PlacementID)
                .ForeignKey("dbo.AppUsers", t => t.Host_ID, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationID, cascadeDelete: true)
                .Index(t => t.LocationID)
                .Index(t => t.Host_ID);

            CreateTable(
                "dbo.AppUsers",
                c => new
                {
                    ID = c.Guid(nullable: false, identity: true),
                    FirstName = c.String(nullable: false, maxLength: 50),
                    LastName = c.String(nullable: false, maxLength: 50),
                    Email = c.String(nullable: false),
                    DateOfBirth = c.DateTime(nullable: false),
                    AFM = c.String(nullable: false, maxLength: 20),
                    IDNo = c.String(nullable: false, maxLength: 10),
                    PhoneNo = c.Int(nullable: false),
                    IsHost = c.Boolean(nullable: false),
                    Accommodation_PlacementID = c.Int(),
                    Experience_ExperienceID = c.Int(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accommodations", t => t.Accommodation_PlacementID)
                .ForeignKey("dbo.Experiences", t => t.Experience_ExperienceID)
                .Index(t => t.Accommodation_PlacementID)
                .Index(t => t.Experience_ExperienceID);

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
                    Floor = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.LocationID);

            CreateTable(
                "dbo.Experiences",
                c => new
                {
                    ExperienceID = c.Int(nullable: false, identity: true),
                    HostID = c.Int(nullable: false),
                    LocationID = c.Int(nullable: false),
                    CreationDate = c.DateTime(nullable: false),
                    AvailableDates = c.DateTime(nullable: false),
                    BookedDates = c.DateTime(nullable: false),
                    HoursAvailable = c.DateTime(nullable: false),
                    Title = c.String(nullable: false),
                    Description = c.String(nullable: false),
                    Shared = c.Boolean(nullable: false),
                    Price = c.Double(nullable: false),
                    MaxCapacity = c.Int(nullable: false),
                    Duration = c.Int(nullable: false),
                    Host_ID = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.ExperienceID)
                .ForeignKey("dbo.AppUsers", t => t.Host_ID, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationID, cascadeDelete: true)
                .Index(t => t.LocationID)
                .Index(t => t.Host_ID);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
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

        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Experiences", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.Experiences", "Host_ID", "dbo.AppUsers");
            DropForeignKey("dbo.AppUsers", "Experience_ExperienceID", "dbo.Experiences");
            DropForeignKey("dbo.Accommodations", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.Accommodations", "Host_ID", "dbo.AppUsers");
            DropForeignKey("dbo.AppUsers", "Accommodation_PlacementID", "dbo.Accommodations");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Experiences", new[] { "Host_ID" });
            DropIndex("dbo.Experiences", new[] { "LocationID" });
            DropIndex("dbo.AppUsers", new[] { "Experience_ExperienceID" });
            DropIndex("dbo.AppUsers", new[] { "Accommodation_PlacementID" });
            DropIndex("dbo.Accommodations", new[] { "Host_ID" });
            DropIndex("dbo.Accommodations", new[] { "LocationID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Experiences");
            DropTable("dbo.Locations");
            DropTable("dbo.AppUsers");
            DropTable("dbo.Accommodations");
        }
    }
}
