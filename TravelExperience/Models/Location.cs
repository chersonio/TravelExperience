using System.Collections.Generic;

namespace TravelExperience.Models.Interface
{
    public class Location
    {
        string Address { get; set; }
        int AddressNo { get; set; }
        string City { get; set; }

        string Country { get; set; }
        int PostalCode { get; set; }

        IDictionary<int, int> MapPoints { get; set; }

        int Floor { get; set; }
    }
}