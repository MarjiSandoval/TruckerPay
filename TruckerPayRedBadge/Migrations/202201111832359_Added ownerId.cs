namespace TruckerPayRedBadge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedownerId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Loads", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Loads", "OwnerId");
        }
    }
}
