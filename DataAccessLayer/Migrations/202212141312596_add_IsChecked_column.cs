namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_IsChecked_column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IsChecked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "IsChecked");
        }
    }
}
