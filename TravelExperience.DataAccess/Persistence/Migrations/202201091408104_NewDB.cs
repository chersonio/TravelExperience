namespace TravelExperience.DataAccess.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionID = c.Guid(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                        SendingWalletID = c.Guid(nullable: false),
                        ReceivingWalletID = c.Guid(nullable: false),
                        BookingID = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TransactionID);
            
            CreateTable(
                "dbo.Wallets",
                c => new
                    {
                        WalletID = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.WalletID);
            
            AddColumn("dbo.AspNetUsers", "WalletID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "WalletID");
            DropTable("dbo.Wallets");
            DropTable("dbo.Transactions");
        }
    }
}
