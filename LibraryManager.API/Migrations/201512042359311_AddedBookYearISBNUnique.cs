namespace LibraryManager.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBookYearISBNUnique : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Year", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "ISBN", c => c.String(maxLength: 30));
            CreateIndex("dbo.Books", "ISBN", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Books", new[] { "ISBN" });
            AlterColumn("dbo.Books", "ISBN", c => c.String());
            DropColumn("dbo.Books", "Year");
        }
    }
}
