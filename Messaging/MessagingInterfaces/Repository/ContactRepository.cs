using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingInterfaces.Model;
//using SQLite;

namespace MessagingInterfaces.Repository
{
    public class ContactRepository
    {
        public ContactRepository()
        {
            InitializeDatabase();
        }
        public IEnumerable<Contact> GetContacts(string user)
        {
            //using (var db = new SQLiteConnection(@"c:\temp\contacts.db"))
            //{
            //    var contacts = db.Table<Contact>().Where(x => x.Username == user).ToList();
            //    return contacts;
            //}
            return null;
        }

        public void SaveContacts(IEnumerable<Contact> contacts)
        {
            //using (var db = new SQLiteConnection(@"c:\temp\contacts.db"))
            //{
            //    foreach (var contact in contacts)
            //        db.InsertOrReplace(contact);
            //}
        }

        private void InitializeDatabase()
        {
            //using (var db = new SQLiteConnection(@"c:\temp\contacts.db"))
            //{
            //    db.CreateTable<Contact>();
            //}
        }
    }
}
