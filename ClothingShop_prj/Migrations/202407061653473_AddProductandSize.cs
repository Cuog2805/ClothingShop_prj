namespace ClothingShop_prj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductandSize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        SizeID = c.Int(nullable: false, identity: true),
                        Amplitude = c.String(),
                    })
                .PrimaryKey(t => t.SizeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sizes");
            DropTable("dbo.Products");
        }
    }
}
