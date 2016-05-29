namespace Bitaka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationUserProducts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Files", "Product_id", "dbo.Products");
            DropIndex("dbo.Files", new[] { "Product_id" });
            DropTable("dbo.Files");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        Product_id = c.Int(),
                    })
                .PrimaryKey(t => t.FileId);
            
            CreateIndex("dbo.Files", "Product_id");
            AddForeignKey("dbo.Files", "Product_id", "dbo.Products", "id");
        }
    }
}
