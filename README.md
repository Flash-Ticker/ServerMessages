# ServerMessages

**__Project details__**

**Project:** *ServerMessages*

**dev language:** *c# oxide*

**Plugin language:** *en*

**Author:** [@RustFlash](https://github.com/Flash-Ticker)

[![RustFlash - Your Favourite Trio Server](https://github.com/Flash-Ticker/ServerMessages/blob/main/ServerMessages_Thumb.jpg)](https://youtu.be/F73j7T1dC6s)


## Description:

The **ServerMessages** plugin for Rust allows server administrators to format and customize the messages in the server chat. With this extension, server messages can be displayed in an appealing way, the formatting and colors can be customized, and the use of certain commands, such as “gave”, can be blocked. This helps to hide F1 items in the chat. It provides an easy way to visually enhance the chat and take control of server-wide messages. 

## Features:
**Chat Icon:** Ability to set a custom SteamID64 chat icon for server messages.
**Command blocking:** Blocks the use of specific commands, such as “gave”, to suppress F1 item messages.
**Customizable message appearance:** Complete control over the appearance of server messages with options to specify title and message color, size and formatting.
**Simple formatting:** Messages can be formatted with a custom template that displays both the title and message in different colors and sizes.
**Server-wide messages:** Senders can send messages directly to all players, which are then displayed according to the specified formatting.

## Permission:
This plugin does not require any special authorizations as it is based on the standard server commands. Commands are blocked by configuration, not by permissions.

## Config: 
```
{
  "Chat Icon (SteamID64)": 0,
  "Block 'gave' Commands (true/false)": true,
  "Message Formatting": {
    "Title": "ServerName",
    "TitleColor": "#FFED00",
    "TitleSize": 15,
    "MessageColor": "#FFFFFF",
    "MessageSize": 15,
    "ChatFormat": "{title}: {message}"
  }
}
```

## More Free Plugins:
If you are looking for more useful free plugins, please have a look at my Discord, you only have to choose the Flash role when you join.
[https://discord.gg/2ftdtaTQ6S](https://discord.gg/2ftdtaTQ6S)



--- 

**load, run, enjoy** 💝


