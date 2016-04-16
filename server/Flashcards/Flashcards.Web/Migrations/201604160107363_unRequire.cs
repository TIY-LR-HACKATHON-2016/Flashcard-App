namespace Flashcards.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unRequire : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cards", "Set_Id", "dbo.Sets");
            DropForeignKey("dbo.Cards", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.Cards", new[] { "Set_Id" });
            DropIndex("dbo.Cards", new[] { "Subject_Id" });
            AlterColumn("dbo.Cards", "Set_Id", c => c.Int());
            AlterColumn("dbo.Cards", "Subject_Id", c => c.Int());
            CreateIndex("dbo.Cards", "Set_Id");
            CreateIndex("dbo.Cards", "Subject_Id");
            AddForeignKey("dbo.Cards", "Set_Id", "dbo.Sets", "Id");
            AddForeignKey("dbo.Cards", "Subject_Id", "dbo.Subjects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cards", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Cards", "Set_Id", "dbo.Sets");
            DropIndex("dbo.Cards", new[] { "Subject_Id" });
            DropIndex("dbo.Cards", new[] { "Set_Id" });
            AlterColumn("dbo.Cards", "Subject_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Cards", "Set_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Cards", "Subject_Id");
            CreateIndex("dbo.Cards", "Set_Id");
            AddForeignKey("dbo.Cards", "Subject_Id", "dbo.Subjects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cards", "Set_Id", "dbo.Sets", "Id", cascadeDelete: true);
        }
    }
}
