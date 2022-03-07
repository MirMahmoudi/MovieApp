namespace MovieApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeBirthdateNullableInCustomersTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Birthdate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Birthdate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
