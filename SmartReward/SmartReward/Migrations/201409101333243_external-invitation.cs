namespace SmartReward.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class externalinvitation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExternalInvitations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeNotificationCode = c.String(),
                        EmailTarget = c.String(),
                        Sender_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Sender_UserId)
                .Index(t => t.Sender_UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ExternalInvitations", new[] { "Sender_UserId" });
            DropForeignKey("dbo.ExternalInvitations", "Sender_UserId", "dbo.Users");
            DropTable("dbo.ExternalInvitations");
        }
    }
}
