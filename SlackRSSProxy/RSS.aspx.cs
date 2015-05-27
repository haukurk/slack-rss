using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;

namespace SlackRSSProxy
{
    public partial class RSS : System.Web.UI.Page
    {
        private ISlackService _slackService = new SlackService(WebConfigurationManager.AppSettings["slacktoken"]);

        protected void Page_Load(object sender, EventArgs e)
        {

            var channelID = Request.QueryString["channel_id"];

            Response.Clear();
            Response.ContentType = "application/rss+xml";

            var res = _slackService.GetMessagesForChannel(channelID);

            if (!res.ok)
            {
                throw new Services.Exceptions.SlackException(res.error);
            }

            RepeaterRSS.DataSource = res.messages;
            RepeaterRSS.DataBind();

        }

        protected string RemoveIllegalCharacters(object input)
        {
            // cast the input to a string
            string data = input.ToString();

            // replace illegal characters in XML documents with their entity references
            data = data.Replace("&", "&amp;");
            data = data.Replace("\"", "&quot;");
            data = data.Replace("'", "&apos;");
            data = data.Replace("<", "&lt;");
            data = data.Replace(">", "&gt;");

            return data;
        }

        protected string SummarizeText(object input)
        {
            // cast the input to a string
            string data = input.ToString();

            if (data.Length > 50)
            {
                return data.Substring(0, 49);
            }

            return data;
        }
    }
}