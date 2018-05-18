namespace MessengerServiceHost.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Participants = c.Int(nullable: false),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        FromId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        DispatchTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.FromId, cascadeDelete: true)
                .Index(t => t.FromId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.MessageContents",
                c => new
                    {
                        MessageContentId = c.Int(nullable: false),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.MessageContentId)
                .ForeignKey("dbo.Messages", t => t.MessageContentId)
                .Index(t => t.MessageContentId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 50),
                        Password = c.Binary(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(maxLength: 50),
                        Phone = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.Login, unique: true)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        Group_GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.Group_GroupId })
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.Group_GroupId, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.Group_GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "FromId", "dbo.Users");
            DropForeignKey("dbo.UserGroups", "Group_GroupId", "dbo.Groups");
            DropForeignKey("dbo.UserGroups", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Messages", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.MessageContents", "MessageContentId", "dbo.Messages");
            DropIndex("dbo.UserGroups", new[] { "Group_GroupId" });
            DropIndex("dbo.UserGroups", new[] { "User_UserId" });
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Users", new[] { "Login" });
            DropIndex("dbo.MessageContents", new[] { "MessageContentId" });
            DropIndex("dbo.Messages", new[] { "GroupId" });
            DropIndex("dbo.Messages", new[] { "FromId" });
            DropTable("dbo.UserGroups");
            DropTable("dbo.Users");
            DropTable("dbo.MessageContents");
            DropTable("dbo.Messages");
            DropTable("dbo.Groups");
        }
    }
}
