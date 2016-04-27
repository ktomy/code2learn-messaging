using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MessagingInterfaces.Model
{
    using System;

    [DataContract]
    public class Contact
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string ContactName { get; set; }
        [DataMember]
        public string ContactUsername { get; set; }
        [DataMember]
        public DateTime CreatedOn { get; set; }
    }

}