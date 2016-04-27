using System.Collections.Generic;

namespace MessagingInterfaces.Model
{
    using System;

    public class Contact
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string ContactName { get; set; }
        public string ContactUsername { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<Contact> FriendList { get; set; }
    }

}