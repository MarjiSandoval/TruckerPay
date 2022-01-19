namespace TruckerPay.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WeeklyPays", "TotalMiles", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WeeklyPays", "TotalMiles");
        }
    }
}
