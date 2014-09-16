namespace SmartReward.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seennotification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "Seen", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "Seen");
        }
    }
}
