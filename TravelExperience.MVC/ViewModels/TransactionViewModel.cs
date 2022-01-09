using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.MVC.ViewModels
{
    public class TransactionViewModel
    {
        public ApplicationUser Host { get; set; }
        public ApplicationUser Traveler { get; set; }
        public string BookingStartDate { get; set; }
        public int BookingID { get; set; }
        public Location Location { get; set; }
    }
}