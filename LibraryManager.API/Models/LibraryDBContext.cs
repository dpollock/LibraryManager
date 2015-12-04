namespace LibraryManager.API.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LibraryDBContext : DbContext
    {
        // Your context has been configured to use a 'LibraryDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'LibraryManager.API.Models.LibraryDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'LibraryDBContext' 
        // connection string in the application configuration file.
        public LibraryDBContext()
            : base("name=LibraryDBContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<CheckOut> Checkouts { get; set; }
    }


}
