namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_role_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 1),
                        Description = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.RoleID);
            
            AddColumn("dbo.Admins", "RoleID", c => c.Int());
            CreateIndex("dbo.Admins", "RoleID");
            AddForeignKey("dbo.Admins", "RoleID", "dbo.Roles", "RoleID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admins", "RoleID", "dbo.Roles");
            DropIndex("dbo.Admins", new[] { "RoleID" });
            DropColumn("dbo.Admins", "RoleID");
            DropTable("dbo.Roles");
        }
    }
}
