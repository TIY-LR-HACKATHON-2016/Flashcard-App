namespace Flashcards.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imgOnSetandSubject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sets", "ImgURL", c => c.String());
            AddColumn("dbo.Subjects", "ImgURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subjects", "ImgURL");
            DropColumn("dbo.Sets", "ImgURL");
        }
    }
}
