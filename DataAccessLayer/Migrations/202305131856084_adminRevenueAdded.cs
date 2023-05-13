namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminRevenueAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "TotalRevenue", c => c.Double(nullable: false));
            AlterColumn("dbo.Instructors", "TotalIncome", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Instructors", "TotalIncome", c => c.Int(nullable: false));
            DropColumn("dbo.Admins", "TotalRevenue");
        }
    }
}
