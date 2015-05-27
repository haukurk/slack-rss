using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using Models;
using Services;

namespace SlackRSSProxy
{
    /// <summary>
    /// Summary description for SlackRSS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    [System.Web.Script.Services.ScriptService]
    public class SlackRSS : System.Web.Services.WebService
    {

        private ISlackService _slackService = new SlackService(WebConfigurationManager.AppSettings["slacktoken"]);

        [WebMethod]
        public Base ChannelRSS(string channel_id)
        {
            var res = _slackService.GetMessagesForChannel(channel_id);

            if (!res.ok)
            {
                throw new Services.Exceptions.SlackException(res.error);
            }

            return res;
        }
    }
}
