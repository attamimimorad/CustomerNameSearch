namespace CustomerNameSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial110220180906AM : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.customersOrigional",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 10),
                        MiddleName = c.String(maxLength: 10),
                        LastName = c.String(maxLength: 10),
                        Phone = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.customersOrigional");
        }
    }
}
