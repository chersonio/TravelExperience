using System.ComponentModel.DataAnnotations;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.MVC.ViewModels
{
    public class AccommodatiosFormViewModel
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        public AccommodationType AccommodationType { get; set; }

        [Required]
        public int MaxCapacity { get; set; }

        public bool Shared { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int AddressNo { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public int PostalCode { get; set; }

        [Required]
        public int Floor { get; set; }

    }
}