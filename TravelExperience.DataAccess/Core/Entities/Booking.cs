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
        [DataType(DataType.Date)]
        public DateTime BookingStartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
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




//Sql("INSERT INTO Accommodations " +
//          "(Title, Description, LocationId ,MaxCapacity, AccommodationTypeID,Shared ,Floor)" +
//          "VALUES" +
//          "('Aston Villa','Luxury Appartments', 20, 4, 1, 'True', 0)," +
//          "('Bellevue Resort and Spa', 'Luxury Appartments at beautiful Sitia of Crete', 21, 10, 3, 'False', 0)");

//Sql("INSERT INTO Bookings" +
//    "(Price, UserID, AccommodationID,  BookingStartDate, BookingEndDate, CreationDate) " +
//    "VALUES(400.00, '11', 3, 2022-09-02, 2022-09-07, 2021-11-26)");


//Sql("INSERT INTO AspNetUsers (AccessFailedCount, LockoutEnabled, TwoFactorEnabled, PhoneNumberConfirmed, Email, EmailConfirmed, Id, UserName, FirstName,LastName,DateOfBirth,VAT,IdentificationNo,Address,AddressNo,City,Country,PostalCode) " +
//    "VALUES " +
//    "(0, 0, 0, 0,'Dylan@in.gr', 0, '11','Dylan@in.gr','Dylan','Villarreal',1991-03-09,'123456799','BN123453','Koemtzi',43,'Athens','Greece',11235), " +
//    "(0, 0, 0, 0,'Akira@in.gr', 0, '12','Akira@in.gr','Akira','Houston',1985-10-05,'223456790','LK123451','Agiou Thoma',56,'Irakleio','Greece',20008)," +
//    "(0, 0, 0, 0,'Evere@in.gr', 0, '13','Evere@in.gr','Everett','Myers',1981-08-13,'563457789','IU123446','Makrigianni',8,'Karditsa','Greece',30050)," +
//    "(0, 0, 0, 0,'Iyana@in.gr', 0, '14','Iyana@in.gr','Iyana','Hinton',1967-11-11,'124986789','EW123456','Volanaki',19,'Kalamata','Greece',20030)," +
//    "(0, 0, 0, 0,'Karle@in.gr', 0, '15','Karle@in.gr','Karlee','Snow',1998-12-21,'131456789','AQ123459','Fragkoklissias',98,'Athens','Greece',11723)," +
//    "(0, 0, 0, 0,'Lance@in.gr', 0, '16','Lance@in.gr','Lance','Gibbs',1977-10-14,'093466789','XZ123456','Kiprou',18,'Lamia','Greece',12363)," +
//    "(0, 0, 0, 0,'Callu@in.gr', 0, '17','Callu@in.gr','Callum','Jackson',1984-19-01,'123456733','VC123458','Akadimias',160,'Athens','Greece',12821)," +
//    "(0, 0, 0, 0,'Denni@in.gr', 0, '18','Denni@in.gr','Dennis','Riley',1966-03-26,'124456589','NB123457','Sina',63,'Athens','Greece',11527)," +
//    "(0, 0, 0, 0,'Natal@in.gr', 0, '19','Natal@in.gr','Natalie','Rodgers',1991-10-28,'133456109','HG123456','Aristotelous',39,'Thessaloniki','Greece',30020)," +
//    "(0, 0, 0, 0,'Collier@in.gr', 0, '20','Collier@in.gr','Emmalee','Collier',1984-08-25,'123552089','KJ123454','Formionos',106,'Athens','Greece',11900)");


//Sql("INSERT INTO Locations " +
//    "(Address, AddressNo, City, Country, PostalCode, Xcoord, Ycoord, AccommodationID)" +
//    "VALUES" +
//    "('Zigkouala', 1, 'Karditsa', 'Greece', 1230123, 10100110, 12030103, 24)," +
//    "('Saronikou', 22, 'Siteia', 'Greece', 1230123, 10100114, 12030106, 20)");


//Sql("DELETE FROM Accommodations");
//Sql("DELETE FROM Experiences");
//Sql("DELETE FROM Bookings");
//Sql("DELETE FROM AspNetUsers");
//Sql("DELETE FROM Locations");
