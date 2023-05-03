namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminDbinit : DbMigration
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
                        email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admins");
        }
    }
}
