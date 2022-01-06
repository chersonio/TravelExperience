using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExperience.DataAccess.Core.Entities
{
    [Flags]
    public enum UtilitiesEnum
    {
        AirConditioning,
        BeachFront,
        CarbonMonoxideAlarm,
        DedicatedWorkspace,
        Dryer,
        FreeParking,
        Gym,
        HairDryer,
        Heating,
        HotTub,
        IndoorFireplace,
        Iron,
        Kitchen,
        Pool,
        SelfCheckIn,
        SmokeAlarm,
        Washer,
        Wifi,
    }

    // https://findnerd.com/list/view/How-to-bind-checkbox-with-enum-values-in-MVC/25707/

    public class Utility
    {
        //[Key]
        public int UtilityID { get; set; }
        public Accommodation Accommodation { get; set; }
        public int AccommodationID { get; set; }

        // Needed for Checkboxes
        public UtilitiesEnum UtilityEnum { get; set; }
        public bool IsSelected { get; set; }
    }
}
