namespace ClothingShop_prj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUserObject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserObjects",
                c => new
                    {
                        UserOjectID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserOjectID);
            
            AddColumn("dbo.Categories", "UserOjectID", c => c.Int(nullable: false));
            CreateIndex("dbo.Categories", "UserOjectID");
            AddForeignKey("dbo.Categories", "UserOjectID", "dbo.UserObjects", "UserOjectID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "UserOjectID", "dbo.UserObjects");
            DropIndex("dbo.Categories", new[] { "UserOjectID" });
            DropColumn("dbo.Categories", "UserOjectID");
            DropTable("dbo.UserObjects");
        }
    }
}
