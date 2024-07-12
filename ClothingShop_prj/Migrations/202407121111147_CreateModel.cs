namespace ClothingShop_prj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        Customer_CustomerID = c.Int(),
                    })
                .PrimaryKey(t => t.AddressID)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerID)
                .Index(t => t.Customer_CustomerID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Carts", t => t.CustomerID)
                .ForeignKey("dbo.Histories", t => t.CustomerID)
                .ForeignKey("dbo.Wishlists", t => t.CustomerID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.AdminCustomers",
                c => new
                    {
                        AdminID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        Action = c.String(nullable: false),
                        ActionTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.AdminID, t.CustomerID })
                .ForeignKey("dbo.Admins", t => t.AdminID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.AdminID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        AdminName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.AdminProducts",
                c => new
                    {
                        AdminID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Action = c.String(nullable: false),
                        ActionTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.AdminID, t.ProductID })
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Admins", t => t.AdminID, cascadeDelete: true)
                .Index(t => t.AdminID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Single(nullable: false),
                        PriceDecreased = c.Single(nullable: false),
                        Avatar = c.String(nullable: false),
                        Material = c.String(),
                        Description = c.String(),
                        Quantity = c.Int(nullable: false),
                        Rate = c.Single(nullable: false),
                        Published = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        CartItemID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Total = c.Single(nullable: false),
                        CartID = c.Int(nullable: false),
                        HistoryID = c.Int(nullable: false),
                        OrderID = c.Int(),
                        ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.CartItemID)
                .ForeignKey("dbo.Carts", t => t.CartID, cascadeDelete: true)
                .ForeignKey("dbo.Histories", t => t.HistoryID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.CartID)
                .Index(t => t.HistoryID)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Total = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.CartID);
            
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        HistoryID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HistoryID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Orderdate = c.DateTime(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.CategoryItems",
                c => new
                    {
                        CategoryItemID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryItemID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ColorID = c.Int(nullable: false, identity: true),
                        Hue = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ColorID);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        ProductImageID = c.Int(nullable: false, identity: true),
                        Url = c.String(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductImageID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        CustomerID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Rate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerID, t.ProductID })
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        SizeID = c.Int(nullable: false, identity: true),
                        Amplitude = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SizeID);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        TypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TypeID);
            
            CreateTable(
                "dbo.Wishlists",
                c => new
                    {
                        WishlistID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.WishlistID);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        DiscountID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Value = c.Int(nullable: false),
                        Expiry = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DiscountID);
            
            CreateTable(
                "dbo.ProductCategoryItem",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        CategoryItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.CategoryItemID })
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.CategoryItems", t => t.CategoryItemID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.CategoryItemID);
            
            CreateTable(
                "dbo.ProductColor",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        ColorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.ColorID })
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Colors", t => t.ColorID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.ColorID);
            
            CreateTable(
                "dbo.ProductSize",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        SizeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.SizeID })
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Sizes", t => t.SizeID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.SizeID);
            
            CreateTable(
                "dbo.Producttype",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        TypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.TypeID })
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Types", t => t.TypeID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.TypeID);
            
            CreateTable(
                "dbo.ProductWishlist",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        WishlistID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.WishlistID })
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Wishlists", t => t.WishlistID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.WishlistID);
            
            CreateTable(
                "dbo.CustomerDiscount",
                c => new
                    {
                        CustomerID = c.Int(nullable: false),
                        DiscountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerID, t.DiscountID })
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Discounts", t => t.DiscountID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.DiscountID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.CustomerDiscount", "DiscountID", "dbo.Discounts");
            DropForeignKey("dbo.CustomerDiscount", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.AdminCustomers", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.AdminProducts", "AdminID", "dbo.Admins");
            DropForeignKey("dbo.ProductWishlist", "WishlistID", "dbo.Wishlists");
            DropForeignKey("dbo.ProductWishlist", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Customers", "CustomerID", "dbo.Wishlists");
            DropForeignKey("dbo.Producttype", "TypeID", "dbo.Types");
            DropForeignKey("dbo.Producttype", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductSize", "SizeID", "dbo.Sizes");
            DropForeignKey("dbo.ProductSize", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Reviews", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductImages", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductColor", "ColorID", "dbo.Colors");
            DropForeignKey("dbo.ProductColor", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductCategoryItem", "CategoryItemID", "dbo.CategoryItems");
            DropForeignKey("dbo.ProductCategoryItem", "ProductID", "dbo.Products");
            DropForeignKey("dbo.CategoryItems", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.CartItems", "ProductID", "dbo.Products");
            DropForeignKey("dbo.CartItems", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.CartItems", "HistoryID", "dbo.Histories");
            DropForeignKey("dbo.Customers", "CustomerID", "dbo.Histories");
            DropForeignKey("dbo.CartItems", "CartID", "dbo.Carts");
            DropForeignKey("dbo.Customers", "CustomerID", "dbo.Carts");
            DropForeignKey("dbo.AdminProducts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.AdminCustomers", "AdminID", "dbo.Admins");
            DropForeignKey("dbo.Addresses", "Customer_CustomerID", "dbo.Customers");
            DropIndex("dbo.CustomerDiscount", new[] { "DiscountID" });
            DropIndex("dbo.CustomerDiscount", new[] { "CustomerID" });
            DropIndex("dbo.ProductWishlist", new[] { "WishlistID" });
            DropIndex("dbo.ProductWishlist", new[] { "ProductID" });
            DropIndex("dbo.Producttype", new[] { "TypeID" });
            DropIndex("dbo.Producttype", new[] { "ProductID" });
            DropIndex("dbo.ProductSize", new[] { "SizeID" });
            DropIndex("dbo.ProductSize", new[] { "ProductID" });
            DropIndex("dbo.ProductColor", new[] { "ColorID" });
            DropIndex("dbo.ProductColor", new[] { "ProductID" });
            DropIndex("dbo.ProductCategoryItem", new[] { "CategoryItemID" });
            DropIndex("dbo.ProductCategoryItem", new[] { "ProductID" });
            DropIndex("dbo.Reviews", new[] { "ProductID" });
            DropIndex("dbo.Reviews", new[] { "CustomerID" });
            DropIndex("dbo.ProductImages", new[] { "ProductID" });
            DropIndex("dbo.CategoryItems", new[] { "CategoryID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropIndex("dbo.CartItems", new[] { "ProductID" });
            DropIndex("dbo.CartItems", new[] { "OrderID" });
            DropIndex("dbo.CartItems", new[] { "HistoryID" });
            DropIndex("dbo.CartItems", new[] { "CartID" });
            DropIndex("dbo.AdminProducts", new[] { "ProductID" });
            DropIndex("dbo.AdminProducts", new[] { "AdminID" });
            DropIndex("dbo.AdminCustomers", new[] { "CustomerID" });
            DropIndex("dbo.AdminCustomers", new[] { "AdminID" });
            DropIndex("dbo.Customers", new[] { "CustomerID" });
            DropIndex("dbo.Addresses", new[] { "Customer_CustomerID" });
            DropTable("dbo.CustomerDiscount");
            DropTable("dbo.ProductWishlist");
            DropTable("dbo.Producttype");
            DropTable("dbo.ProductSize");
            DropTable("dbo.ProductColor");
            DropTable("dbo.ProductCategoryItem");
            DropTable("dbo.Discounts");
            DropTable("dbo.Wishlists");
            DropTable("dbo.Types");
            DropTable("dbo.Sizes");
            DropTable("dbo.Reviews");
            DropTable("dbo.ProductImages");
            DropTable("dbo.Colors");
            DropTable("dbo.Categories");
            DropTable("dbo.CategoryItems");
            DropTable("dbo.Orders");
            DropTable("dbo.Histories");
            DropTable("dbo.Carts");
            DropTable("dbo.CartItems");
            DropTable("dbo.Products");
            DropTable("dbo.AdminProducts");
            DropTable("dbo.Admins");
            DropTable("dbo.AdminCustomers");
            DropTable("dbo.Customers");
            DropTable("dbo.Addresses");
        }
    }
}
