using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface ISlackService
    {
        bool CheckAuthentication();
        Base GetMessagesForChannel(string channel_id);
    }
}
