namespace TravelExperience.DataAccess.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateAccommodationTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AccommodationTypes (Name) VALUES ('Room')");
            Sql("INSERT INTO AccommodationTypes (Name) VALUES ('Appartment')");
            Sql("INSERT INTO AccommodationTypes (Name) VALUES ('Villa')");
            Sql("INSERT INTO AccommodationTypes (Name) VALUES ('Hostel')");
            Sql("INSERT INTO AccommodationTypes (Name) VALUES ('Hotel')");
            Sql("INSERT INTO AccommodationTypes (Name) VALUES ('Bed And Breakfast')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM AccommodationTypes");
        }
    }
}
