using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingInterfaces.Model;
using MessagingInterfaces.Repository;

namespace MessagingServerController
{
    internal class ApiConnector
    {
        private readonly ContactRepository applicationRepository;

        internal ApiConnector()
        {
            applicationRepository= new ContactRepository();
        }
        public IEnumerable<Contact> GetContacts(string username)
        {
            try
            {
                return applicationRepository.GetContacts(username);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void SaveContacts(List<Contact> contacts)
        {
            try
            {
                applicationRepository.SaveContacts(contacts);
            }
            catch (Exception)
            {
               return;
            }
        }
    }
}
