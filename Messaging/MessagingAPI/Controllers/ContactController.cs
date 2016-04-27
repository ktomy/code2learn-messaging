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

        [HttpGet]
        public IEnumerable<Contact> Get(string id)
        {
                return _repository.GetContacts(id);
        }

        [HttpPost]
        public void Post([FromBody]Contact contact)
        {

            contact.CreatedOn = DateTime.Now;
            _repository.SaveContacts(new List<Contact>() {contact});
        }
    }
}
