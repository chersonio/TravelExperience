namespace TravelExperience.DataAccess.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ChangedCoordsToFloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Locations", "Xcoord", c => c.Single(nullable: false));
            AlterColumn("dbo.Locations", "Ycoord", c => c.Single(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.Locations", "Ycoord", c => c.Int(nullable: false));
            AlterColumn("dbo.Locations", "Xcoord", c => c.Int(nullable: false));
        }
    }
}
