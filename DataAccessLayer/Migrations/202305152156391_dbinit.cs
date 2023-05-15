namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbinit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Admin_name = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        PhoneNo = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        AdminImage = c.String(nullable: false),
                        TotalRevenue = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false, maxLength: 50),
                        CatagoryId = c.Int(nullable: false),
                        InstructorId = c.Int(nullable: false),
                        Rating = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Catagories", t => t.CatagoryId, cascadeDelete: true)
                .ForeignKey("dbo.Instructors", t => t.InstructorId, cascadeDelete: true)
                .Index(t => t.CatagoryId)
                .Index(t => t.InstructorId);
            
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.CourseContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.CourseReviews",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        Review = c.String(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.CourseStudents",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Rating = c.Int(nullable: false),
                        PurchaseAt = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Student_name = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Dob = c.DateTime(nullable: false),
                        PhoneNo = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Registration = c.DateTime(nullable: false),
                        fund = c.Double(nullable: false),
                        action = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        TotalIncome = c.Double(nullable: false),
                        Rating = c.Double(nullable: false),
                        JoinedAt = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NoticeBoards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Notice = c.String(nullable: false),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Carts", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Carts", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "InstructorId", "dbo.Instructors");
            DropForeignKey("dbo.CourseStudents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.CourseStudents", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseReviews", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseContents", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "CatagoryId", "dbo.Catagories");
            DropIndex("dbo.OrderDetails", new[] { "StudentId" });
            DropIndex("dbo.CourseStudents", new[] { "StudentId" });
            DropIndex("dbo.CourseStudents", new[] { "CourseId" });
            DropIndex("dbo.CourseReviews", new[] { "CourseId" });
            DropIndex("dbo.CourseContents", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "InstructorId" });
            DropIndex("dbo.Courses", new[] { "CatagoryId" });
            DropIndex("dbo.Carts", new[] { "StudentId" });
            DropIndex("dbo.Carts", new[] { "CourseId" });
            DropTable("dbo.OrderDetails");
            DropTable("dbo.NoticeBoards");
            DropTable("dbo.Instructors");
            DropTable("dbo.Students");
            DropTable("dbo.CourseStudents");
            DropTable("dbo.CourseReviews");
            DropTable("dbo.CourseContents");
            DropTable("dbo.Catagories");
            DropTable("dbo.Courses");
            DropTable("dbo.Carts");
            DropTable("dbo.Admins");
        }
    }
}
