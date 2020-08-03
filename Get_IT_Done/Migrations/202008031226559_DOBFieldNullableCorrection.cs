namespace Get_IT_Done.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DOBFieldNullableCorrection : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
