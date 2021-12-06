﻿namespace TravelExperience.DataAccess.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHostIdToAccommodations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accommodations", "Host", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accommodations", "Host");
        }
    }
}
