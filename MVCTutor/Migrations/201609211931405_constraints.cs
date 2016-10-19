namespace MVCTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class constraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TblEmployee", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.TblEmployee", "LastName", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TblEmployee", "LastName", c => c.String());
            AlterColumn("dbo.TblEmployee", "FirstName", c => c.String());
        }
    }
}
