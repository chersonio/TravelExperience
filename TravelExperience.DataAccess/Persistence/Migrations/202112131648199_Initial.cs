namespace TravelExperience.DataAccess.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "ExperienceID", "dbo.Experiences");
            DropIndex("dbo.Bookings", new[] { "ExperienceID" });
            DropColumn("dbo.Bookings", "ExperienceID");
            DropTable("dbo.Experiences");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.Bookings", "ExperienceID", c => c.Int());
            CreateIndex("dbo.Bookings", "ExperienceID");
            AddForeignKey("dbo.Bookings", "ExperienceID", "dbo.Experiences", "ExperienceID");
        }
    }
}
