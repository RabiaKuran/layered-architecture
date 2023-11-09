namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        FilmID = c.Int(nullable: false, identity: true),
                        vizyonTarihi = c.DateTime(nullable: false),
                        filmTuru = c.String(maxLength: 50),
                        filmIsmi = c.String(maxLength: 50),
                        hIciFiyat = c.Single(nullable: false),
                        hSonuFiyat = c.Single(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilmID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Films", new[] { "CategoryID" });
            DropTable("dbo.Films");
            DropTable("dbo.Categories");
        }
    }
}
