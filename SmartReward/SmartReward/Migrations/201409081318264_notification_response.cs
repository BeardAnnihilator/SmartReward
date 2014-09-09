namespace SmartReward.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notification_response : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserUsers",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        User_UserId1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.User_UserId1 })
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .ForeignKey("dbo.Users", t => t.User_UserId1)
                .Index(t => t.User_UserId)
                .Index(t => t.User_UserId1);
            
            AddColumn("dbo.Notifications", "Value", c => c.Boolean());
            AddColumn("dbo.Notifications", "Query_Id", c => c.Int());
            AddForeignKey("dbo.Notifications", "Query_Id", "dbo.Notifications", "Id");
            CreateIndex("dbo.Notifications", "Query_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserUsers", new[] { "User_UserId1" });
            DropIndex("dbo.UserUsers", new[] { "User_UserId" });
            DropIndex("dbo.Notifications", new[] { "Query_Id" });
            DropForeignKey("dbo.UserUsers", "User_UserId1", "dbo.Users");
            DropForeignKey("dbo.UserUsers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Notifications", "Query_Id", "dbo.Notifications");
            DropColumn("dbo.Notifications", "Query_Id");
            DropColumn("dbo.Notifications", "Value");
            DropTable("dbo.UserUsers");
        }
    }
}
