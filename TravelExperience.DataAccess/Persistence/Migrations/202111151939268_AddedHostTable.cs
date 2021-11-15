namespace TravelExperience.DataAccess.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHostTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hosts",
                c => new
                    {
                        HostID = c.Int(nullable: false, identity: true),
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
                .PrimaryKey(t => t.HostID);
            
            CreateIndex("dbo.Bookings", "HostID");
            AddForeignKey("dbo.Bookings", "HostID", "dbo.Hosts", "HostID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "HostID", "dbo.Hosts");
            DropIndex("dbo.Bookings", new[] { "HostID" });
            DropTable("dbo.Hosts");
        }
    }
}
