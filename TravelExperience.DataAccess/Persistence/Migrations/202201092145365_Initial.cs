namespace TravelExperience.DataAccess.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Transactions");
            AddColumn("dbo.Bookings", "PhoneNumber", c => c.String());
            AddColumn("dbo.Bookings", "Email", c => c.String());
            AlterColumn("dbo.Transactions", "TransactionID", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Transactions", "TransactionID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Transactions");
            AlterColumn("dbo.Transactions", "TransactionID", c => c.Guid(nullable: false));
            DropColumn("dbo.Bookings", "Email");
            DropColumn("dbo.Bookings", "PhoneNumber");
            AddPrimaryKey("dbo.Transactions", "TransactionID");
        }
    }
}
