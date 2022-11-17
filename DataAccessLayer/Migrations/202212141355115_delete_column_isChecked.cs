namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete_column_isChecked : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "IsChecked");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "IsChecked", c => c.Boolean(nullable: false));
        }
    }
}
