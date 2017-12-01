namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerWithBirthDates : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate ='1988-04-19 00:00:00' WHERE Id = 1 ");
        }
        
        public override void Down()
        {
        }
    }
}
