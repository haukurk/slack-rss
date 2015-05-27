<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RSS.aspx.cs" Inherits="SlackRSSProxy.RSS" ResponseEncoding="UTF-8" %>

<asp:Repeater ID="RepeaterRSS" runat="server">
        <HeaderTemplate>
           <?xml version="1.0" encoding="utf-8"?>
           <rss version="2.0">
                <channel>
                    <title>RSS Proxy Feed</title>
                    <link>http://slack.com</link>
                    <description>
                    This feed is built on a proxy for slack.com
                    </description>
        </HeaderTemplate>
        <ItemTemplate>
            <item>
                <title><%# SummarizeText(DataBinder.Eval(Container.DataItem, "text"))%></title>
                <link>http://slack.com</link>
                <author><%# RemoveIllegalCharacters(DataBinder.Eval(Container.DataItem, "user"))%></author>
                <pubDate><%# String.Format("{0:R}", DataBinder.Eval(Container.DataItem, "ts"))%></pubDate>
                <description><%# RemoveIllegalCharacters(DataBinder.Eval(Container.DataItem, "text"))%></description>
            </item>
        </ItemTemplate>
        <FooterTemplate>
                </channel>
            </rss>  
        </FooterTemplate>
</asp:Repeater>