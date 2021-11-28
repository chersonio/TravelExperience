using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExperience.DataAccess.Core.Entities
{
    /// <summary>
    /// o tropos pou katanow na leitourgei to sigkekrimeno xtisimo einai o eksis: 
    /// 1. To Bookings einai to kentriko table pou ola syndeontai.
    /// 2. Enas host dimiourgei experience/accommodation kai dimiourgountai se ena booking me to TravelerID tou san HostID.
    /// 3. Oi users psaxnoun bookings na kleisoun.
    /// 4. Otan enas user epileksei poio tha kleisei dimourgei ena extra booking, me hostID kai accommodation/experience-ID tou 2. (blepe parapanw)
    /// 5. sto booking dilwnetai poies imerominies tha einai ekei. Kai etsi bgainei i timi/mera.
    /// </summary>
    public class Booking
    {
        // maybe we will need a table receipts
        [Key]
        public int BookingID { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int? AccommodationID { get; set; }

        public Accommodation Accommodation { get; set; }

        public int? ExperienceID { get; set; }

        public Experience Experience { get; set; }

        [Required]
        public DateTime BookingStartDate { get; set; }

        [Required]
        public DateTime BookingEndDate { get; set; }

        // To Booking StartDate - EndDate tha prepe na nai ksexwristos pinakas.  Afora: 
        // oson afora ta booking start dates , efoson xrisimopoioume kai host kai traveler to idio, 
        // o host tha xreiazetai available dates se pinaka, 
        // enw o traveler xreiazetai to monadiko date pou thelei na ksekinaei-teleiwnei i imerominia afiksis-apoxwrisis tou
        // PARADEIGMA:
        // Tha mporouse enas host na einai diathesimo apo-ews : 15-30/11, 15-30/12

        [Required]
        public DateTime CreationDate { get; set; } // Imerominia dimiourgias
    }
}

// o tropos pou katanow na leitourgei to sigkekrimeno xtisimo einai o eksis:
// 1. To Bookings einai to kentriko table pou ola syndeontai.
// 2. Enas host dimiourgei experience/accommodation kai dimiourgountai se ena booking me to TravelerID tou san HostID.
// 3. Oi users psaxnoun bookings na kleisoun.
// 4. Otan enas user epileksei poio tha kleisei dimourgei ena extra booking, me hostID kai accommodation/experience-ID tou 2. (blepe parapanw)
// 5. sto booking dilwnetai poies imerominies tha einai ekei. Kai etsi bgainei i timi/mera.




//Sql("INSERT INTO Travelers (FirstName,LastName,DateOfBirth,VAT,IdentificationNo,Address,AddressNo,City,Country,PostalCode) " +
//    "VALUES ('Dylan','Villarreal',1991-03-09,'123456799','BN123453','Koemtzi',43,'Athens','Greece',11235), " +
//    "('Akira','Houston',1985-10-05,'223456790','LK123451','Agiou Thoma',56,'Irakleio','Greece',20008)," +
//    "('Everett','Myers',1981-08-13,'563457789','IU123446','Makrigianni',8,'Karditsa','Greece',30050)," +
//    "('Iyana','Hinton',1967-11-11,'124986789','EW123456','Volanaki',19,'Kalamata','Greece',20030)," +
//    "('Karlee','Snow',1998-12-21,'131456789','AQ123459','Fragkoklissias',98,'Athens','Greece',11723)," +
//    "('Lance','Gibbs',1977-10-14,'093466789','XZ123456','Kiprou',18,'Lamia','Greece',12363)," +
//    "('Callum','Jackson',1984-19-01,'123456733','VC123458','Akadimias',160,'Athens','Greece',12821)," +
//    "('Dennis','Riley',1966-03-26,'124456589','NB123457','Sina',63,'Athens','Greece',11527)," +
//    "('Natalie','Rodgers',1991-10-28,'133456109','HG123456','Aristotelous',39,'Thessaloniki','Greece',30020)," +
//    "('Emmalee','Collier',1984-08-25,'123552089','KJ123454','Formionos',106,'Athens','Greece',11900)");


//Sql("INSERT INTO Hosts (FirstName,LastName,DateOfBirth,VAT,IdentificationNo,Address,AddressNo,City,Country,PostalCode) " +
//    "VALUES ('Hailie','Guerrero',1990-03-04,'123456789','AB123456','Stadiou',23,'Athens','Greece',11234)," +
//    "('Tate','Stephens',1985-09-05,'223456789','PO123456','Panepistimiou',118,'Athens','Greece',11534)," +
//    "('Adan','Reilly',1980-03-13,'563456789','WE123456','Georgiou Papandreou',6,'Athens','Greece',11833)," +
//    "('Jarrett','Lane',1966-01-28,'123986789','XS123456','Papagou',19,'Athens','Greece',11326)," +
//    "('Zaria','Chung',1999-12-27,'130456789','EF123456','Agias Annis',32,'Athens','Greece',11723)," +
//    "('Makai ','Fernandez',1976-10-05,'093456789','MN123456','Katehaki',48,'Athens','Greece',12363)," +
//    "('Jamari','Howard',1983-05-01,'123456723','TR123456','Skoufa',99,'Athens','Greece',11821)," +
//    "('Dominique','Villegas',1969-02-03,'123456589','PC123456','Mesinias',87,'Athens','Greece',11526)," +
//    "('Ada','Hill',1992-09-22,'123456109','MK123456','Xatzikwnstanti',39,'Athens','Greece',11623)," +
//    "('Jesse','Prince',1987-07-24,'123452089','CD123456','Formionos',106,'Athens','Greece',11900)");


//Sql("INSERT INTO Accommodations " +
//    "(Title,Description,AccommodationType,MaxCapacity,CreationDate,AvailableDates,BookedDates,Shared,Address,AddressNo,City,Country,PostalCode,Floor) " +
//    "VALUES ('Aston Villa','Luxury Appartments',3,4,2020-03-01,2021-12-20,2021-11-21,0,'Agias Paraskevis',5,'Kalamata','Greece',2001,0)");


//Sql("INSERT INTO Experiences " +
//    "(Title,Description,MaxCapacity,CreationDate,AvailableDates,BookedDates,Shared,Address,AddressNo,City,Country,PostalCode) " +
//    "VALUES ('Hiking','Hiking at Parnitha Mountain',10,2020-04-01,2021-12-22,2021-11-10,1,'Leoforos Marathonos',207,'Athens','Greece',11823)");


//Sql("INSERT INTO Bookings" +
//    "(Price,HostID,ExperienceID,BookingStartDate,BookingEndDate) " +
//    "VALUES(400.00,1,1,2021-09-02,2021-09-07)");


//Sql("DELETE FROM Travelers");
//Sql("DELETE FROM Hosts");
//Sql("DELETE FROM Accommodations");
//Sql("DELETE FROM Experiences");
//Sql("DELETE FROM Bookings");