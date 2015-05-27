using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Models;
using Services.Clients;

namespace Services
{
    public class SlackService : ISlackService
    {

        // Ratings API Client for the IT Technical API.
        readonly ISlackClient _slackAPI;

        public SlackService(string auth_token)
        {
            _slackAPI = new SlackClient(auth_token);
        }

        public bool CheckAuthentication()
        {
            var asyncRatingsObject = _slackAPI.Get<Base>("auth.test");
            var result = asyncRatingsObject.Result;

            if (result.ok != true)
                return false;

            return true;
        }

        public Base GetMessagesForChannel(string channel_id)
        {
            var asyncRatingsObject = _slackAPI.Get<Base>(String.Format("channels.history?channel={0}", channel_id));
            var result = asyncRatingsObject.Result;
            return result;
        }
    }
}
