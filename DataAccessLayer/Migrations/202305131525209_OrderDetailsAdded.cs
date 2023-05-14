namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderDetailsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CheckoutAt = c.DateTime(nullable: false),
                        TotalPayment = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            AlterColumn("dbo.CourseStudents", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "StudentId", "dbo.Students");
            DropIndex("dbo.OrderDetails", new[] { "StudentId" });
            AlterColumn("dbo.CourseStudents", "Price", c => c.Single(nullable: false));
            DropTable("dbo.OrderDetails");
        }
    }
}
