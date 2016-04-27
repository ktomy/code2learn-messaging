using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingInterfaces.Model;

namespace MessagingInterfaces
{
    public class BaseContext : DbContext
    {
        public BaseContext(): base("name=ConnectionString")
        {
            if (!Database.Exists())
                Database.Create();
        }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
