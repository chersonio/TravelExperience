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

        public int HostID { get; set; }

        [ForeignKey("Traveler")]// den ebala gia ta accom kai exp
        public int TravelerID { get; set; }
        public Traveler Traveler { get; set; }

        public Accommodation Accommodation { get; set; }//

        public int AccommodationID { get; set; }//


        public Experience Experience { get; set; } //
        public int ExperienceID { get; set; } // 

        [Required]
        public DateTime BookingStartDate { get; set; }
        [Required]
        public DateTime BookingEndDate { get; set; }

    }

}

// o tropos pou katanow na leitourgei to sigkekrimeno xtisimo einai o eksis:
// 1. To Bookings einai to kentriko table pou ola syndeontai.
// 2. Enas host dimiourgei experience/accommodation kai dimiourgountai se ena booking me to TravelerID tou san HostID.
// 3. Oi users psaxnoun bookings na kleisoun.
// 4. Otan enas user epileksei poio tha kleisei dimourgei ena extra booking, me hostID kai accommodation/experience-ID tou 2. (blepe parapanw)
// 5. sto booking dilwnetai poies imerominies tha einai ekei. Kai etsi bgainei i timi/mera.