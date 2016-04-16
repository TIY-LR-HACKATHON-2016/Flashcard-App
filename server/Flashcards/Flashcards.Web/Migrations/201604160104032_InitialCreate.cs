namespace Flashcards.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        frontText = c.String(nullable: false),
                        backText = c.String(nullable: false),
                        Set_Id = c.Int(nullable: false),
                        Subject_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sets", t => t.Set_Id, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .Index(t => t.Set_Id)
                .Index(t => t.Subject_Id);
            
            CreateTable(
                "dbo.Sets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id)
                .Index(t => t.Subject_Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cards", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Sets", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Cards", "Set_Id", "dbo.Sets");
            DropIndex("dbo.Sets", new[] { "Subject_Id" });
            DropIndex("dbo.Cards", new[] { "Subject_Id" });
            DropIndex("dbo.Cards", new[] { "Set_Id" });
            DropTable("dbo.Subjects");
            DropTable("dbo.Sets");
            DropTable("dbo.Cards");
        }
    }
}
