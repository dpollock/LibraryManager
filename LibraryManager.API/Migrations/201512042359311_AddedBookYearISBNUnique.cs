namespace LibraryManager.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBookYearISBNUnique : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Year", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "ISBN", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Books", new[] { "ISBN" });
            DropColumn("dbo.Books", "Year");
        }
    }
}
