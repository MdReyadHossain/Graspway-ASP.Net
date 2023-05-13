namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cartPrice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Carts", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Carts", "Price", c => c.Int(nullable: false));
        }
    }
}
