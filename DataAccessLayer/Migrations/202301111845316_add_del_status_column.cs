namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_del_status_column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "DeleteStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "DeleteStatus");
        }
    }
}
