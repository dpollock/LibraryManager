namespace LibraryManager.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        ISBN = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CheckOuts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCheckedOut = c.DateTime(nullable: false),
                        DateExpectedReturn = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Book_Id = c.Int(),
                        CheckedOutTo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .ForeignKey("dbo.Students", t => t.CheckedOutTo_Id)
                .Index(t => t.Book_Id)
                .Index(t => t.CheckedOutTo_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckOuts", "CheckedOutTo_Id", "dbo.Students");
            DropForeignKey("dbo.CheckOuts", "Book_Id", "dbo.Books");
            DropIndex("dbo.CheckOuts", new[] { "CheckedOutTo_Id" });
            DropIndex("dbo.CheckOuts", new[] { "Book_Id" });
            DropTable("dbo.Students");
            DropTable("dbo.CheckOuts");
            DropTable("dbo.Books");
        }
    }
}
