namespace OAuth.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExternalUserLoginTableCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExternalUserLogins",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey });
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false,maxLength: 256));
            CreateIndex("dbo.Users", "UserName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "UserName" });
            DropTable("dbo.ExternalUserLogins");
        }
    }
}
