namespace TruckerPay.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoadPays",
                c => new
                    {
                        LoadPayId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        LoadId = c.Int(nullable: false),
                        PerDiemRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PayRateLoaded = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PayRateEmpty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SentToPayroll = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LoadPayId)
                .ForeignKey("dbo.Loads", t => t.LoadId, cascadeDelete: true)
                .Index(t => t.LoadId);
            
            CreateTable(
                "dbo.Loads",
                c => new
                    {
                        LoadId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        LoadNumber = c.Long(nullable: false),
                        ShipperLocation = c.String(nullable: false),
                        ReceiverLocation = c.String(nullable: false),
                        PickUpAppt = c.DateTime(nullable: false),
                        DeliveryAppt = c.DateTime(nullable: false),
                        ShipperName = c.String(nullable: false),
                        ReceiverName = c.String(nullable: false),
                        ShipperPhone = c.Long(nullable: false),
                        ReceiverPhone = c.Long(nullable: false),
                        EmptyMiles = c.Int(nullable: false),
                        LoadedMiles = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LoadId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.WeeklyPays",
                c => new
                    {
                        WeeklyPayId = c.Int(nullable: false, identity: true),
                        PayDate = c.DateTime(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        StartPayWeek = c.DateTime(nullable: false),
                        EndPayWeek = c.DateTime(nullable: false),
                        HealthInsuranceCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DentalInsuranceCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LifeInsuranceCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LayOverPay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AdvancesTaken = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BreakdownPay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DetentionPay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bonuses = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.WeeklyPayId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.LoadPays", "LoadId", "dbo.Loads");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.LoadPays", new[] { "LoadId" });
            DropTable("dbo.WeeklyPays");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Loads");
            DropTable("dbo.LoadPays");
        }
    }
}
