using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.Clients
{
    interface ISlackClient
    {
        Task<T> Get<T>(string uri);
    }
}
