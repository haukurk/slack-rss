using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Base
    {
        public bool ok { get; set; }
        public string has_more { get; set; }
        public string is_limited { get; set; }
        public List<Messages> messages { get; set; }
        public string error { get; set; }
    }
}
