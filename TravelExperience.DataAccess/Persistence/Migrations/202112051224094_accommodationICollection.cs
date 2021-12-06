namespace TravelExperience.DataAccess.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class accommodationICollection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accommodations", "HostID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Accommodations", "HostID");
            AddForeignKey("dbo.Accommodations", "HostID", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Accommodations", "Host");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accommodations", "Host", c => c.String());
            DropForeignKey("dbo.Accommodations", "HostID", "dbo.AspNetUsers");
            DropIndex("dbo.Accommodations", new[] { "HostID" });
            DropColumn("dbo.Accommodations", "HostID");
        }
    }
}
