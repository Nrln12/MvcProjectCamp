namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "AuthorID", c => c.Int());
            CreateIndex("dbo.Headings", "AuthorID");
            AddForeignKey("dbo.Headings", "AuthorID", "dbo.Authors", "AuthorID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Headings", "AuthorID", "dbo.Authors");
            DropIndex("dbo.Headings", new[] { "AuthorID" });
            DropColumn("dbo.Headings", "AuthorID");
        }
    }
}
