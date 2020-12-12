namespace neighborhoodStore3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        ProductName = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SalesID = c.Int(nullable: false, identity: true),
                        PruductID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        ClientType = c.Int(),
                        Product_ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.SalesID)
                .ForeignKey("dbo.Products", t => t.Product_ProductID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.Product_ProductID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstMidName = c.String(),
                        SalesDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "UserID", "dbo.Users");
            DropForeignKey("dbo.Sales", "Product_ProductID", "dbo.Products");
            DropIndex("dbo.Sales", new[] { "Product_ProductID" });
            DropIndex("dbo.Sales", new[] { "UserID" });
            DropTable("dbo.Users");
            DropTable("dbo.Sales");
            DropTable("dbo.Products");
        }
    }
}
