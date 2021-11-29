namespace TravelExperience.DataAccess.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddSeed : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO Locations " +
                "(Address, AddressNo, City, Country, PostalCode, Xcoord, Ycoord, AccommodationID)" +
                "VALUES" +
                "('Zigkouala', 1, 'Karditsa', 'Greece', 1230123, 10100110, 12030103, 1)," +
                "('Saronikou', 22, 'Siteia', 'Greece', 1230123, 10100114, 12030106, 2)");

        


            Sql("INSERT INTO AspNetUsers (AccessFailedCount, LockoutEnabled, TwoFactorEnabled, PhoneNumberConfirmed, Email, EmailConfirmed, Id, UserName, FirstName,LastName,DateOfBirth,VAT,IdentificationNo,Address,AddressNo,City,Country,PostalCode) " +
                "VALUES " +
                "(0, 0, 0, 0,'Dylan@in.gr', 0, '1','Dylan@in.gr','Dylan','Villarreal',1991-03-09,'123456799','BN123453','Koemtzi',43,'Athens','Greece',11235), " +
                "(0, 0, 0, 0,'Akira@in.gr', 0, '2','Akira@in.gr','Akira','Houston',1985-10-05,'223456790','LK123451','Agiou Thoma',56,'Irakleio','Greece',20008)," +
                "(0, 0, 0, 0,'Evere@in.gr', 0, '3','Evere@in.gr','Everett','Myers',1981-08-13,'563457789','IU123446','Makrigianni',8,'Karditsa','Greece',30050)," +
                "(0, 0, 0, 0,'Iyana@in.gr', 0, '4','Iyana@in.gr','Iyana','Hinton',1967-11-11,'124986789','EW123456','Volanaki',19,'Kalamata','Greece',20030)," +
                "(0, 0, 0, 0,'Karle@in.gr', 0, '5','Karle@in.gr','Karlee','Snow',1998-12-21,'131456789','AQ123459','Fragkoklissias',98,'Athens','Greece',11723)," +
                "(0, 0, 0, 0,'Lance@in.gr', 0, '6','Lance@in.gr','Lance','Gibbs',1977-10-14,'093466789','XZ123456','Kiprou',18,'Lamia','Greece',12363)," +
                "(0, 0, 0, 0,'Callu@in.gr', 0, '7','Callu@in.gr','Callum','Jackson',1984-19-01,'123456733','VC123458','Akadimias',160,'Athens','Greece',12821)," +
                "(0, 0, 0, 0,'Denni@in.gr', 0, '8','Denni@in.gr','Dennis','Riley',1966-03-26,'124456589','NB123457','Sina',63,'Athens','Greece',11527)," +
                "(0, 0, 0, 0,'Natal@in.gr', 0, '9','Natal@in.gr','Natalie','Rodgers',1991-10-28,'133456109','HG123456','Aristotelous',39,'Thessaloniki','Greece',30020)," +
                "(0, 0, 0, 0,'Collier@in.gr', 0, '10','Collier@in.gr','Emmalee','Collier',1984-08-25,'123552089','KJ123454','Formionos',106,'Athens','Greece',11900)");
        }

        public override void Down()
        {

            Sql("DELETE FROM AspNetUsers");
            Sql("DELETE FROM Locations");
        }
    }
}
