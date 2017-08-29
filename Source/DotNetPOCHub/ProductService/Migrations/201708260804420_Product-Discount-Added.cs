namespace ProductService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductDiscountAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "DiscountPer", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "DiscountPer");
        }
    }
}
