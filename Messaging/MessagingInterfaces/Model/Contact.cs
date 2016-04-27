using System;
using SQLite;

namespace MessagingInterfaces.Model
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        [MaxLength(128)]
        public string Username { get; set; }
        [MaxLength(128)]
        public string ContactName { get; set; }
        [MaxLength(128)]
        public string ContactUsername { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
