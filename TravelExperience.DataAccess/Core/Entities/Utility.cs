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
        Wifi
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


        //[NotMapped]
        //public bool IsChecked { get; set; }
        //public bool Value { get; set; }
        //public ICollection<AccommodationUtilities> AccommodationUtilities { get; set; }

        //public ICollection<Accommodation> Accommodations { get; set; }

        //public bool BeachFront { get; set; }
        //public bool Pool { get; set; }
        //public bool Wifi { get; set; }
        //public bool Kitchen { get; set; }
        //public bool HotTub { get; set; }
        //public bool Washer { get; set; }
        //public bool SelfCheckIn { get; set; }
        //public bool DedicatedWorkspace { get; set; }
        //public bool SmokeAlarm { get; set; }
        //public bool CarbonMonoxideAlarm { get; set; }
        //public bool HairDryer { get; set; }
        //public bool Iron { get; set; }
        //public bool Dryer { get; set; }
        //public bool Heating { get; set; }
        //public bool IndoorFireplace { get; set; }
        //public bool BeacAirConditioninghFront { get; set; }
        //public bool Gym { get; set; }
        //public bool FreeParking { get; set; }



        //public string BeachFrontID { get; set; }
        //public string WifiID { get; set; }
        //public string KitchenID { get; set; }
        //public string HotTubID { get; set; }
        //public string WasherID { get; set; }
        //public string SelfCheckInID { get; set; }
        //public string PoolID { get; set; }
        //public string FreeParkingID { get; set; }
        //public string DedicatedWorkspaceID { get; set; }
        //public string SmokeAlarmID { get; set; }
        //public string CarbonMonoxideAlarmID { get; set; }
        //public string HairDryerID { get; set; }
        //public string IronID { get; set; }
        //public string DryerID { get; set; }
        //public string HeatingID { get; set; }
        //public string IndoorFireplaceID { get; set; }
        //public string BeacAirConditioninghFrontID { get; set; }
        //public string GymID { get; set; }
    }
}
