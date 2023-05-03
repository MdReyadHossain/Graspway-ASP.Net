namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.CourseReviews",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Review = c.String(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.CourseStudents",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Student_name = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Dob = c.String(nullable: false),
                        PhoneNo = c.String(nullable: false),
                        email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Admins", "adminImage", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "adminImage");
            DropTable("dbo.Students");
            DropTable("dbo.CourseStudents");
            DropTable("dbo.CourseReviews");
            DropTable("dbo.Catagories");
        }
    }
}
