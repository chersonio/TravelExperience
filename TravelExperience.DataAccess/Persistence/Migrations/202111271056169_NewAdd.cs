namespace TravelExperience.DataAccess.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilities", "HairDryerID", c => c.String());
            AddColumn("dbo.Utilities", "HairDryer", c => c.Boolean(nullable: false));
            DropColumn("dbo.Utilities", "HaiDryerID");
            DropColumn("dbo.Utilities", "HaiDryer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Utilities", "HaiDryer", c => c.Boolean(nullable: false));
            AddColumn("dbo.Utilities", "HaiDryerID", c => c.String());
            DropColumn("dbo.Utilities", "HairDryer");
            DropColumn("dbo.Utilities", "HairDryerID");
        }
    }
}
