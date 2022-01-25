namespace TruckerPay.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmtandloadedmiles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoadPays", "EmptyMiles", c => c.Int(nullable: false));
            AddColumn("dbo.LoadPays", "LoadedMiles", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LoadPays", "LoadedMiles");
            DropColumn("dbo.LoadPays", "EmptyMiles");
        }
    }
}
