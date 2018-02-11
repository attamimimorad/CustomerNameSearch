namespace CustomerNameSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneLength110220180908AM : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.customersOrigional", "Phone", c => c.String(maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.customersOrigional", "Phone", c => c.String(maxLength: 10));
        }
    }
}
