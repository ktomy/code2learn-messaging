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
        readonly BaseContext _context;
        public ContactRepository()
        {
            _context = new BaseContext();
        }
        public IEnumerable<Contact> GetContacts(string user)
        {
            return _context.Contacts.Where(x => x.Username == user).ToList();
        }

        public void SaveContacts(IEnumerable<Contact> contacts)
        {
            foreach (var contact in contacts)
                _context.Contacts.Add(contact);
            _context.SaveChanges();
        }
        
    }
}
