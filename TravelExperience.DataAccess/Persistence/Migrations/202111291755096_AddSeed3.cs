namespace TravelExperience.DataAccess.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddSeed3 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Bookings" +
                "(Price, UserID, AccommodationID,  BookingStartDate, BookingEndDate, CreationDate) " +
                "VALUES(400.00, '10', 12, 2022-09-02, 2022-09-07, 2021-11-26)");
        }

        public override void Down()
        {
            Sql("DELETE FROM Bookings");
        }
    }
}
