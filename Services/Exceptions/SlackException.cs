using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
    public class SlackException : Exception
    {
        public SlackException()
        {

        }

        public SlackException(string message)
            : base(message)
        {

        }

        public SlackException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
