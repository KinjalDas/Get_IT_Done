namespace Get_IT_Done.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypesDBSeed : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT MembershipTypes ON");
            Sql("INSERT INTO MembershipTypes (Id,TypeName,Duration,Charges) VALUES (1,'FREE PLAN',0,0)");
            Sql("INSERT INTO MembershipTypes (Id,TypeName,Duration,Charges) VALUES (2,'MONTHLY PLAN',1,250)");
            Sql("INSERT INTO MembershipTypes (Id,TypeName,Duration,Charges) VALUES (3,'QUARTERLY PLAN',3,500)");
            Sql("INSERT INTO MembershipTypes (Id,TypeName,Duration,Charges) VALUES (4,'ANNUAL PLAN',12,1500)");
            Sql("SET IDENTITY_INSERT MembershipTypes ON");
        }
        
        public override void Down()
        {
        }
    }
}
