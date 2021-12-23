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
// 2. Enas host dimiourgei accommodation kai dimiourgountai se ena booking me to TravelerID tou san HostID.
// 3. Oi users psaxnoun bookings na kleisoun.
// 4. Otan enas user epileksei poio tha kleisei dimourgei ena extra booking, me hostID kai accommodation tou 2. (blepe parapanw)
// 5. sto booking dilwnetai poies imerominies tha einai ekei. Kai etsi bgainei i timi/mera.