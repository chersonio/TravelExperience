using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.MVC.ViewModels
{
    public class MapViewModel
    {
        public IEnumerable<Location> Locations { get; set; }
        public bool ShowLocations { get; set; }
    }
}