namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class normalizationAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
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
                        InstructorName = c.String(nullable: false),
                        Rating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Catagories", t => t.CatagoryId, cascadeDelete: true)
                .Index(t => t.CatagoryId);
            
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
                "dbo.Instructors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        InstructorImage = c.String(nullable: false),
                        TotalIncome = c.Int(nullable: false),
                        Rating = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CourseReviews", "CourseId", c => c.Int(nullable: false));
            AddColumn("dbo.CourseStudents", "CourseId", c => c.Int(nullable: false));
            AddColumn("dbo.CourseStudents", "StudentId", c => c.Int(nullable: false));
            AddColumn("dbo.CourseStudents", "Price", c => c.Single(nullable: false));
            AddColumn("dbo.CourseStudents", "PurchaseAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Students", "StudentImage", c => c.String(nullable: false));
            AddColumn("dbo.Students", "fund", c => c.Double(nullable: false));
            AddColumn("dbo.Students", "action", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Students", "Dob", c => c.DateTime(nullable: false));
            CreateIndex("dbo.CourseReviews", "CourseId");
            CreateIndex("dbo.CourseStudents", "CourseId");
            CreateIndex("dbo.CourseStudents", "StudentId");
            AddForeignKey("dbo.CourseReviews", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CourseStudents", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CourseStudents", "StudentId", "dbo.Students", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Carts", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseStudents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.CourseStudents", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseReviews", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseContents", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "CatagoryId", "dbo.Catagories");
            DropIndex("dbo.CourseStudents", new[] { "StudentId" });
            DropIndex("dbo.CourseStudents", new[] { "CourseId" });
            DropIndex("dbo.CourseReviews", new[] { "CourseId" });
            DropIndex("dbo.CourseContents", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "CatagoryId" });
            DropIndex("dbo.Carts", new[] { "StudentId" });
            DropIndex("dbo.Carts", new[] { "CourseId" });
            AlterColumn("dbo.Students", "Dob", c => c.String(nullable: false));
            DropColumn("dbo.Students", "action");
            DropColumn("dbo.Students", "fund");
            DropColumn("dbo.Students", "StudentImage");
            DropColumn("dbo.CourseStudents", "PurchaseAt");
            DropColumn("dbo.CourseStudents", "Price");
            DropColumn("dbo.CourseStudents", "StudentId");
            DropColumn("dbo.CourseStudents", "CourseId");
            DropColumn("dbo.CourseReviews", "CourseId");
            DropTable("dbo.Instructors");
            DropTable("dbo.CourseContents");
            DropTable("dbo.Courses");
            DropTable("dbo.Carts");
        }
    }
}
