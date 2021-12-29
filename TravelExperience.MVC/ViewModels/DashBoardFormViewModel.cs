using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Persistence;

namespace TravelExperience.MVC.ViewModels
{
    public class DashBoardFormViewModel
    {
        public UnitOfWork UnitOfWork { get; set; }

        public Booking Booking { get; set; }
        public Accommodation Accommodation { get; set; }


        public List<Accommodation> Accommodations { get; set; }
        public List<Booking> Bookings { get; set; }

        [Display(Name = "Total Price")]
        public IDictionary<Booking, decimal> PriceOfBooking { get; set; } 
    
    }
}