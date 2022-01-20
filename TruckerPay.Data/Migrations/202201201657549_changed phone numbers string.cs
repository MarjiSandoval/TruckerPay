namespace TruckerPay.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedphonenumbersstring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Loads", "ShipperPhone", c => c.String());
            AlterColumn("dbo.Loads", "ReceiverPhone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Loads", "ReceiverPhone", c => c.Long(nullable: false));
            AlterColumn("dbo.Loads", "ShipperPhone", c => c.Long(nullable: false));
        }
    }
}
