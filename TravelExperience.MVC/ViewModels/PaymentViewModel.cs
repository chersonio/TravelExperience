using System;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.MVC.ViewModels
{
    public class PaymentViewModel
    {
        public int AccommodationID { get; set; }
        public ApplicationUser Traveler { get; set; }
        public decimal TotalPaymentAmount { get; set; }
        public decimal WalletAmount { get; set; }
        public string AccommodationTitle { get; set; }
        public int Guests { get; set; }
        public string BookingStartDate { get; set; }
        public string BookingEndDate { get; set; }
    }
}
