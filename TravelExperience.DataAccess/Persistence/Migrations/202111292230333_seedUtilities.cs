namespace TravelExperience.DataAccess.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUtilities : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Utilities  (UtilitiesOfAccommodationID,Name) VALUES (1,'Beach Front')");
            Sql("INSERT INTO Utilities  (UtilitiesOfAccommodationID,Name) VALUES (2,'Wifi')");
            Sql("INSERT INTO Utilities  (UtilitiesOfAccommodationID,Name) VALUES (3,'Kitchen')");
            Sql("INSERT INTO Utilities  (UtilitiesOfAccommodationID,Name) VALUES (4,'Hot Tub')");
            Sql("INSERT INTO Utilities  (UtilitiesOfAccommodationID,Name) VALUES (5,'Washer')");
            Sql("INSERT INTO Utilities  (UtilitiesOfAccommodationID,Name) VALUES (6,'Self Check In')");
            Sql("INSERT INTO Utilities  (UtilitiesOfAccommodationID,Name) VALUES (7,'Pool')");
            Sql("INSERT INTO Utilities  (UtilitiesOfAccommodationID,Name) VALUES (8,'Free Parking')");
            Sql("INSERT INTO Utilities  (UtilitiesOfAccommodationID,Name) VALUES (9,'Dedicated Workspace')");
            Sql("INSERT INTO Utilities  (UtilitiesOfAccommodationID,Name) VALUES (10,'Smoke Alarm')");
            Sql("INSERT INTO Utilities  (UtilitiesOfAccommodationID,Name) VALUES (11,'Carbon Monoxide Alarm')");
            Sql("INSERT INTO Utilities  (UtilitiesOfAccommodationID,Name) VALUES (12,'Hair Dryer')");
            Sql("INSERT INTO Utilities  (UtilitiesOfAccommodationID,Name) VALUES (13,'Iron')");
            Sql("INSERT INTO Utilities  (UtilitiesOfAccommodationID,Name) VALUES (14,'Dryer')");
            Sql("INSERT INTO Utilities  (UtilitiesOfAccommodationID,Name) VALUES (15,'Heating')");
            Sql("INSERT INTO Utilities  (UtilitiesOfAccommodationID,Name) VALUES (16,'Indoor Fireplace')");
            Sql("INSERT INTO Utilities  (UtilitiesOfAccommodationID,Name) VALUES (17,'AirConditioning')");
            Sql("INSERT INTO Utilities  (UtilitiesOfAccommodationID,Name) VALUES (18,'Gym')");

        }
        
        public override void Down()
        {
            Sql("DELETE FROM Utilities");
        }
    }
}
