namespace Test2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandID = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                    })
                .PrimaryKey(t => t.BrandID);
            
            CreateTable(
                "dbo.DeviceModels",
                c => new
                    {
                        ModelID = c.Int(nullable: false, identity: true),
                        ModelName = c.String(),
                        BrandID = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RAM = c.Int(nullable: false),
                        StorageCapacity = c.Int(nullable: false),
                        OpSystemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModelID)
                .ForeignKey("dbo.Brands", t => t.BrandID, cascadeDelete: true)
                .ForeignKey("dbo.OpSystems", t => t.OpSystemID, cascadeDelete: true)
                .Index(t => t.BrandID)
                .Index(t => t.OpSystemID);
            
            CreateTable(
                "dbo.OpSystems",
                c => new
                    {
                        OpSystemID = c.Int(nullable: false, identity: true),
                        OpSystemName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.OpSystemID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeviceModels", "OpSystemID", "dbo.OpSystems");
            DropForeignKey("dbo.DeviceModels", "BrandID", "dbo.Brands");
            DropIndex("dbo.DeviceModels", new[] { "OpSystemID" });
            DropIndex("dbo.DeviceModels", new[] { "BrandID" });
            DropTable("dbo.OpSystems");
            DropTable("dbo.DeviceModels");
            DropTable("dbo.Brands");
        }
    }
}
