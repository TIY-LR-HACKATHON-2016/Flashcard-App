namespace Flashcards.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRequirements : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sets", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Subjects", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subjects", "Name", c => c.String());
            AlterColumn("dbo.Sets", "Name", c => c.String());
        }
    }
}
