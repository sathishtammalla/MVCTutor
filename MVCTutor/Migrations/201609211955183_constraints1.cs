namespace MVCTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class constraints1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TblEmployee", "FirstName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TblEmployee", "FirstName", c => c.String(nullable: false));
        }
    }
}
