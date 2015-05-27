slack-rss
=====================================

# Overview
The project is structured like the following:
* Models (Slack models for serialization)
* Services (Services and Clients that interact with Slack API)
* SlackRSSProxy (Web solution that shows an example on how to create a RSS feed from Slack.com channels by using the services provided in this project).

# Configuration

The ```SlackRSSProxy``` has some configuration requirements to be able to authenticate successfully with Slack API.

Configuration parameters are included in ```Web.config``` like such:
```
<configuration>
    <appSettings>
      <add key="slacktoken" value="xoxp-xxxxx-xxxxx-xxxxxxxx-ac68cc"/>
    </appSettings>
	...
</configuration>
``` 

The ```slacktoken``` keeps the authentication token provided by Slack.com.