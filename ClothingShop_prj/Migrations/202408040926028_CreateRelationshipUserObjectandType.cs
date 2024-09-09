namespace ClothingShop_prj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRelationshipUserObjectandType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Types", "UserObjectID", c => c.Int(nullable: false));
            CreateIndex("dbo.Types", "UserObjectID");
            AddForeignKey("dbo.Types", "UserObjectID", "dbo.UserObjects", "UserOjectID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Types", "UserObjectID", "dbo.UserObjects");
            DropIndex("dbo.Types", new[] { "UserObjectID" });
            DropColumn("dbo.Types", "UserObjectID");
        }
    }
}
