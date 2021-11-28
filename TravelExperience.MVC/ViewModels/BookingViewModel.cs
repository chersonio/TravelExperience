using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.MVC.ViewModels
{
    internal class BookingViewModel
    {
        [Key]
        public int BookingID { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
        public IEnumerable<Accommodation> Accommodations { get; set; }
        public IEnumerable<Experience> Experiences { get; set; }
        public DateTime BookingStartDate { get; set; }
        public DateTime BookingEndDate { get; set; }
        public DateTime CreationDate { get; set; } // Imerominia dimiourgias
    }
}