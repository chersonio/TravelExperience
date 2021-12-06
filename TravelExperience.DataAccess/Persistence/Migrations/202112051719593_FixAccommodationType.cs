namespace TravelExperience.DataAccess.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixAccommodationType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccommodationTypes",
                c => new
                    {
                        TypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TypeId);
            
            AddColumn("dbo.Accommodations", "AccommodationType_TypeId", c => c.Int());
            AlterColumn("dbo.Accommodations", "AccommodationTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Accommodations", "AccommodationType_TypeId");
            AddForeignKey("dbo.Accommodations", "AccommodationType_TypeId", "dbo.AccommodationTypes", "TypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accommodations", "AccommodationType_TypeId", "dbo.AccommodationTypes");
            DropIndex("dbo.Accommodations", new[] { "AccommodationType_TypeId" });
            AlterColumn("dbo.Accommodations", "AccommodationTypeID", c => c.String());
            DropColumn("dbo.Accommodations", "AccommodationType_TypeId");
            DropTable("dbo.AccommodationTypes");
        }
    }
}
