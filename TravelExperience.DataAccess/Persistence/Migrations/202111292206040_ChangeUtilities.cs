namespace TravelExperience.DataAccess.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUtilities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilities", "Name", c => c.String());
            DropColumn("dbo.AccommodationUtilities", "Exists");
            DropColumn("dbo.Utilities", "BeachFrontID");
            DropColumn("dbo.Utilities", "BeachFront");
            DropColumn("dbo.Utilities", "WifiID");
            DropColumn("dbo.Utilities", "Wifi");
            DropColumn("dbo.Utilities", "KitchenID");
            DropColumn("dbo.Utilities", "Kitchen");
            DropColumn("dbo.Utilities", "HotTubID");
            DropColumn("dbo.Utilities", "HotTub");
            DropColumn("dbo.Utilities", "WasherID");
            DropColumn("dbo.Utilities", "Washer");
            DropColumn("dbo.Utilities", "SelfCheckInID");
            DropColumn("dbo.Utilities", "SelfCheckIn");
            DropColumn("dbo.Utilities", "PoolID");
            DropColumn("dbo.Utilities", "Pool");
            DropColumn("dbo.Utilities", "FreeParkingID");
            DropColumn("dbo.Utilities", "FreeParking");
            DropColumn("dbo.Utilities", "DedicatedWorkspaceID");
            DropColumn("dbo.Utilities", "DedicatedWorkspace");
            DropColumn("dbo.Utilities", "SmokeAlarmID");
            DropColumn("dbo.Utilities", "SmokeAlarm");
            DropColumn("dbo.Utilities", "CarbonMonoxideAlarmID");
            DropColumn("dbo.Utilities", "CarbonMonoxideAlarm");
            DropColumn("dbo.Utilities", "HairDryerID");
            DropColumn("dbo.Utilities", "HairDryer");
            DropColumn("dbo.Utilities", "IronID");
            DropColumn("dbo.Utilities", "Iron");
            DropColumn("dbo.Utilities", "DryerID");
            DropColumn("dbo.Utilities", "Dryer");
            DropColumn("dbo.Utilities", "HeatingID");
            DropColumn("dbo.Utilities", "Heating");
            DropColumn("dbo.Utilities", "IndoorFireplaceID");
            DropColumn("dbo.Utilities", "IndoorFireplace");
            DropColumn("dbo.Utilities", "BeacAirConditioninghFrontID");
            DropColumn("dbo.Utilities", "BeacAirConditioninghFront");
            DropColumn("dbo.Utilities", "GymID");
            DropColumn("dbo.Utilities", "Gym");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Utilities", "Gym", c => c.Boolean(nullable: false));
            AddColumn("dbo.Utilities", "GymID", c => c.String());
            AddColumn("dbo.Utilities", "BeacAirConditioninghFront", c => c.Boolean(nullable: false));
            AddColumn("dbo.Utilities", "BeacAirConditioninghFrontID", c => c.String());
            AddColumn("dbo.Utilities", "IndoorFireplace", c => c.Boolean(nullable: false));
            AddColumn("dbo.Utilities", "IndoorFireplaceID", c => c.String());
            AddColumn("dbo.Utilities", "Heating", c => c.Boolean(nullable: false));
            AddColumn("dbo.Utilities", "HeatingID", c => c.String());
            AddColumn("dbo.Utilities", "Dryer", c => c.Boolean(nullable: false));
            AddColumn("dbo.Utilities", "DryerID", c => c.String());
            AddColumn("dbo.Utilities", "Iron", c => c.Boolean(nullable: false));
            AddColumn("dbo.Utilities", "IronID", c => c.String());
            AddColumn("dbo.Utilities", "HairDryer", c => c.Boolean(nullable: false));
            AddColumn("dbo.Utilities", "HairDryerID", c => c.String());
            AddColumn("dbo.Utilities", "CarbonMonoxideAlarm", c => c.Boolean(nullable: false));
            AddColumn("dbo.Utilities", "CarbonMonoxideAlarmID", c => c.String());
            AddColumn("dbo.Utilities", "SmokeAlarm", c => c.Boolean(nullable: false));
            AddColumn("dbo.Utilities", "SmokeAlarmID", c => c.String());
            AddColumn("dbo.Utilities", "DedicatedWorkspace", c => c.Boolean(nullable: false));
            AddColumn("dbo.Utilities", "DedicatedWorkspaceID", c => c.String());
            AddColumn("dbo.Utilities", "FreeParking", c => c.Boolean(nullable: false));
            AddColumn("dbo.Utilities", "FreeParkingID", c => c.String());
            AddColumn("dbo.Utilities", "Pool", c => c.Boolean(nullable: false));
            AddColumn("dbo.Utilities", "PoolID", c => c.String());
            AddColumn("dbo.Utilities", "SelfCheckIn", c => c.Boolean(nullable: false));
            AddColumn("dbo.Utilities", "SelfCheckInID", c => c.String());
            AddColumn("dbo.Utilities", "Washer", c => c.Boolean(nullable: false));
            AddColumn("dbo.Utilities", "WasherID", c => c.String());
            AddColumn("dbo.Utilities", "HotTub", c => c.Boolean(nullable: false));
            AddColumn("dbo.Utilities", "HotTubID", c => c.String());
            AddColumn("dbo.Utilities", "Kitchen", c => c.Boolean(nullable: false));
            AddColumn("dbo.Utilities", "KitchenID", c => c.String());
            AddColumn("dbo.Utilities", "Wifi", c => c.Boolean(nullable: false));
            AddColumn("dbo.Utilities", "WifiID", c => c.String());
            AddColumn("dbo.Utilities", "BeachFront", c => c.Boolean(nullable: false));
            AddColumn("dbo.Utilities", "BeachFrontID", c => c.String());
            AddColumn("dbo.AccommodationUtilities", "Exists", c => c.Boolean(nullable: false));
            DropColumn("dbo.Utilities", "Name");
        }
    }
}
