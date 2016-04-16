namespace Flashcards.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImgToCards : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cards", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Cards", "Set_Id", "dbo.Sets");
            DropForeignKey("dbo.Sets", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.Cards", new[] { "Set_Id" });
            DropIndex("dbo.Cards", new[] { "Subject_Id" });
            DropIndex("dbo.Sets", new[] { "Subject_Id" });
            AddColumn("dbo.Cards", "FrontImgURL", c => c.String());
            AddColumn("dbo.Cards", "BackImgURL", c => c.String());
            AlterColumn("dbo.Cards", "Set_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Sets", "Subject_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Cards", "Set_Id");
            CreateIndex("dbo.Sets", "Subject_Id");
            AddForeignKey("dbo.Cards", "Set_Id", "dbo.Sets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sets", "Subject_Id", "dbo.Subjects", "Id", cascadeDelete: true);
            DropColumn("dbo.Cards", "Subject_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cards", "Subject_Id", c => c.Int());
            DropForeignKey("dbo.Sets", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Cards", "Set_Id", "dbo.Sets");
            DropIndex("dbo.Sets", new[] { "Subject_Id" });
            DropIndex("dbo.Cards", new[] { "Set_Id" });
            AlterColumn("dbo.Sets", "Subject_Id", c => c.Int());
            AlterColumn("dbo.Cards", "Set_Id", c => c.Int());
            DropColumn("dbo.Cards", "BackImgURL");
            DropColumn("dbo.Cards", "FrontImgURL");
            CreateIndex("dbo.Sets", "Subject_Id");
            CreateIndex("dbo.Cards", "Subject_Id");
            CreateIndex("dbo.Cards", "Set_Id");
            AddForeignKey("dbo.Sets", "Subject_Id", "dbo.Subjects", "Id");
            AddForeignKey("dbo.Cards", "Set_Id", "dbo.Sets", "Id");
            AddForeignKey("dbo.Cards", "Subject_Id", "dbo.Subjects", "Id");
        }
    }
}
