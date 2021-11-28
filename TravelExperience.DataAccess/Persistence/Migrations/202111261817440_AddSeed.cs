namespace TravelExperience.DataAccess.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddSeed : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Accommodations " +
               "(Title, Description, LocationId ,MaxCapacity, AccommodationTypeID,Shared ,Floor)" +
               "VALUES" +
               "('Aston Villa','Luxury Appartments', 20, 4, 1, 'True', 0)," +
               "('Bellevue Resort and Spa', 'Luxury Appartments at beautiful Sitia of Crete', 21, 10, 3, 'False', 0)");

            ////Sql("INSERT INTO Experiences " +
            ////    "(Title,Description,MaxCapacity,CreationDate,AvailableDates,BookedDates,Shared,Address,AddressNo,City,Country,PostalCode) " +
            ////    "VALUES ('Hiking','Hiking at Parnitha Mountain',10,2020-04-01,2021-12-22,2021-11-10,1,'Leoforos Marathonos',207,'Athens','Greece',11823)");


            Sql("INSERT INTO Bookings" +
                "(Price, UserID, AccommodationID,  BookingStartDate, BookingEndDate, CreationDate) " +
                "VALUES(400.00, '11', 3, 2022-09-02, 2022-09-07, 2021-11-26)");
        }

        public override void Down()
        {
        }
    }
}
