namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_datatype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Skills", "SkillRange", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Skills", "SkillRange", c => c.String());
        }
    }
}
