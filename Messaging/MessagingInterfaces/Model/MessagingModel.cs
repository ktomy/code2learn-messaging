namespace MessagingInterfaces.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MessagingModel : DbContext
    {
        // Your context has been configured to use a 'MessagingModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MessagingInterfaces.Model.MessagingModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MessagingModel' 
        // connection string in the application configuration file.
        public MessagingModel()
            : base("name=MessagingModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    public class Contact
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string ContactName { get; set; }
        public string ContactUsername { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}