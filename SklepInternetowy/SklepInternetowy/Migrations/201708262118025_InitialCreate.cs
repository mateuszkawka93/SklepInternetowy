namespace SklepInternetowy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 100),
                        CategoryDescription = c.String(nullable: false),
                        IconFileName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Supplement",
                c => new
                    {
                        SupplementId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Producer = c.String(nullable: false, maxLength: 100),
                        AddTime = c.DateTime(nullable: false),
                        ImageFileName = c.String(maxLength: 100),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bestseller = c.Boolean(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SupplementId)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.OrderPosition",
                c => new
                    {
                        OrderPositionId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        SupplementId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderPositionId)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Supplement", t => t.SupplementId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.SupplementId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Surname = c.String(nullable: false, maxLength: 40),
                        Street = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 30),
                        Zipcode = c.String(nullable: false, maxLength: 6),
                        Telephone = c.String(),
                        Email = c.String(),
                        Comment = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        OrderStatus = c.Int(nullable: false),
                        OrderValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderPosition", "SupplementId", "dbo.Supplement");
            DropForeignKey("dbo.OrderPosition", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Supplement", "CategoryId", "dbo.Category");
            DropIndex("dbo.OrderPosition", new[] { "SupplementId" });
            DropIndex("dbo.OrderPosition", new[] { "OrderId" });
            DropIndex("dbo.Supplement", new[] { "CategoryId" });
            DropTable("dbo.Order");
            DropTable("dbo.OrderPosition");
            DropTable("dbo.Supplement");
            DropTable("dbo.Category");
        }
    }
}
