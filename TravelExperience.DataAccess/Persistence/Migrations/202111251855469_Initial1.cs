namespace TravelExperience.DataAccess.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Bookings", name: "Id", newName: "UserId");
            RenameIndex(table: "dbo.Bookings", name: "IX_Id", newName: "IX_UserId");

            Sql("INSERT INTO Travelers (FirstName,LastName,DateOfBirth,VAT,IdentificationNo,Address,AddressNo,City,Country,PostalCode) " +
                "VALUES ('Dylan','Villarreal',1991-03-09,'123456799','BN123453','Koemtzi',43,'Athens','Greece',11235), " +
                "('Akira','Houston',1985-10-05,'223456790','LK123451','Agiou Thoma',56,'Irakleio','Greece',20008)," +
                "('Everett','Myers',1981-08-13,'563457789','IU123446','Makrigianni',8,'Karditsa','Greece',30050)," +
                "('Iyana','Hinton',1967-11-11,'124986789','EW123456','Volanaki',19,'Kalamata','Greece',20030)," +
                "('Karlee','Snow',1998-12-21,'131456789','AQ123459','Fragkoklissias',98,'Athens','Greece',11723)," +
                "('Lance','Gibbs',1977-10-14,'093466789','XZ123456','Kiprou',18,'Lamia','Greece',12363)," +
                "('Callum','Jackson',1984-19-01,'123456733','VC123458','Akadimias',160,'Athens','Greece',12821)," +
                "('Dennis','Riley',1966-03-26,'124456589','NB123457','Sina',63,'Athens','Greece',11527)," +
                "('Natalie','Rodgers',1991-10-28,'133456109','HG123456','Aristotelous',39,'Thessaloniki','Greece',30020)," +
                "('Emmalee','Collier',1984-08-25,'123552089','KJ123454','Formionos',106,'Athens','Greece',11900)");


            Sql("INSERT INTO Hosts (FirstName,LastName,DateOfBirth,VAT,IdentificationNo,Address,AddressNo,City,Country,PostalCode) " +
                "VALUES ('Hailie','Guerrero',1990-03-04,'123456789','AB123456','Stadiou',23,'Athens','Greece',11234)," +
                "('Tate','Stephens',1985-09-05,'223456789','PO123456','Panepistimiou',118,'Athens','Greece',11534)," +
                "('Adan','Reilly',1980-03-13,'563456789','WE123456','Georgiou Papandreou',6,'Athens','Greece',11833)," +
                "('Jarrett','Lane',1966-01-28,'123986789','XS123456','Papagou',19,'Athens','Greece',11326)," +
                "('Zaria','Chung',1999-12-27,'130456789','EF123456','Agias Annis',32,'Athens','Greece',11723)," +
                "('Makai ','Fernandez',1976-10-05,'093456789','MN123456','Katehaki',48,'Athens','Greece',12363)," +
                "('Jamari','Howard',1983-05-01,'123456723','TR123456','Skoufa',99,'Athens','Greece',11821)," +
                "('Dominique','Villegas',1969-02-03,'123456589','PC123456','Mesinias',87,'Athens','Greece',11526)," +
                "('Ada','Hill',1992-09-22,'123456109','MK123456','Xatzikwnstanti',39,'Athens','Greece',11623)," +
                "('Jesse','Prince',1987-07-24,'123452089','CD123456','Formionos',106,'Athens','Greece',11900)");


            Sql("INSERT INTO Accommodations " +
                "(Title,Description,AccommodationType,MaxCapacity,CreationDate,AvailableDates,BookedDates,Shared,Address,AddressNo,City,Country,PostalCode,Floor) " +
                "VALUES ('Aston Villa','Luxury Appartments',3,4,2020-03-01,2021-12-20,2021-11-21,0,'Agias Paraskevis',5,'Kalamata','Greece',2001,0)");


            Sql("INSERT INTO Experiences " +
                "(Title,Description,MaxCapacity,CreationDate,AvailableDates,BookedDates,Shared,Address,AddressNo,City,Country,PostalCode) " +
                "VALUES ('Hiking','Hiking at Parnitha Mountain',10,2020-04-01,2021-12-22,2021-11-10,1,'Leoforos Marathonos',207,'Athens','Greece',11823)");


            Sql("INSERT INTO Bookings" +
                "(Price,HostID,ExperienceID,BookingStartDate,BookingEndDate) " +
                "VALUES(400.00,1,1,2021-09-02,2021-09-07)");
        }

        public override void Down()
        {
            RenameIndex(table: "dbo.Bookings", name: "IX_UserId", newName: "IX_Id");
            RenameColumn(table: "dbo.Bookings", name: "UserId", newName: "Id");

            Sql("DELETE FROM Travelers");
            Sql("DELETE FROM Hosts");
            Sql("DELETE FROM Accommodations");
            Sql("DELETE FROM Experiences");
            Sql("DELETE FROM Bookings");
        }
    }
}
