namespace Flashcards.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSetandSubject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sets", "Name", c => c.String());
            AddColumn("dbo.Subjects", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subjects", "Name");
            DropColumn("dbo.Sets", "Name");
        }
    }
}
