namespace TravelExperience.DataAccess.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddSeed2 : DbMigration
    {
        public override void Up()
        {
            //Sql("INSERT INTO Accommodations " +
            //     "(Title, Description, LocationId ,MaxCapacity, AccommodationTypeID,Shared ,Floor)" +
            //     "VALUES" +
            //     "('Aston Villa','Luxury Appartments', 2, 4, 1, 'True', 0)," +
            //     "('Bellevue Resort and Spa', 'Luxury Appartments at beautiful Sitia of Crete', 9, 10, 3, 'False', 0)");




        }

        public override void Down()
        {

            Sql("DELETE FROM Accommodations");
            //Sql("DELETE FROM Experiences");
        }
    }
}
