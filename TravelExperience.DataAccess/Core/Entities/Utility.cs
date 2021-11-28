using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelExperience.DataAccess.Core.Entities
{
    public class Utility
    {
        [Key]
        public string UtilitiesOfAccommodationID { get; set; }

        public virtual ICollection<AccommodationUtilities> AccommodationUtilities { get; set; }

        public string BeachFrontID { get; set; }
        public bool BeachFront { get; set; }

        public string WifiID { get; set; }
        public bool Wifi { get; set; }

        public string KitchenID { get; set; }
        public bool Kitchen { get; set; }

        public string HotTubID { get; set; }
        public bool HotTub { get; set; }

        public string WasherID { get; set; }
        public bool Washer { get; set; }

        public string SelfCheckInID { get; set; }
        public bool SelfCheckIn { get; set; }

        public string PoolID { get; set; }
        public bool Pool { get; set; }

        public string FreeParkingID { get; set; }
        public bool FreeParking { get; set; }

        public string DedicatedWorkspaceID { get; set; }
        public bool DedicatedWorkspace { get; set; }

        public string SmokeAlarmID { get; set; }
        public bool SmokeAlarm { get; set; }

        public string CarbonMonoxideAlarmID { get; set; }
        public bool CarbonMonoxideAlarm { get; set; }

        public string HairDryerID { get; set; }
        public bool HairDryer { get; set; }

        public string IronID { get; set; }
        public bool Iron { get; set; }

        public string DryerID { get; set; }
        public bool Dryer { get; set; }

        public string HeatingID { get; set; }
        public bool Heating { get; set; }

        public string IndoorFireplaceID { get; set; }
        public bool IndoorFireplace { get; set; }

        public string BeacAirConditioninghFrontID { get; set; }
        public bool BeacAirConditioninghFront { get; set; }

        public string GymID { get; set; }

        public bool Gym { get; set; }
    }
}
