namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class instructorNameDroped : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "InstructorName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "InstructorName", c => c.String(nullable: false));
        }
    }
}
