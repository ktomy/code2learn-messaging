using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MessagingServerController.Model
{
    class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        [MaxLength(128)]
        public string Username { get; set; }
        [MaxLength(128)]
        public string ContactName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
