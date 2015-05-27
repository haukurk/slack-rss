using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Messages
    {
        public string type { get; set; }
        public string user { get; set; }
        public string text { get; set; }
        public DateTime ts { get; set; }
    }
}
