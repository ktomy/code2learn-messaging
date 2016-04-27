using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MessagingInterfaces.Model;
using MessagingInterfaces.Repository;

namespace MessagingAPI.Controllers
{
    public class ContactController : ApiController
    {
        private ContactRepository _repository = new ContactRepository();
        public IEnumerable<Contact> Get(string username)
        {
            return _repository.GetContacts(username);
        }
        public void Post([FromBody]Contact contact)
        {
            
            _repository.SaveContacts(new List<Contact>() {contact});
        }
    }
}
