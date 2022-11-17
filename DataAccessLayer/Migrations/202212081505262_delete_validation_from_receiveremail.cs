namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete_validation_from_receiveremail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "RececiverMail", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "RececiverMail", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
