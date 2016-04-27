using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalDataProvider
{
    public class RESTParams
    {
        public string RestURL { get; set; }
        public string RestURLParams { get; set; }
        public IEnumerable<string> HeadersInfo { get; set; }
    }
}
