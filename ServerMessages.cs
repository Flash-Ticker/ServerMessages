using Newtonsoft.Json;
using System;

namespace Oxide.Plugins
{
    [Info("ServerMessages", "RustFlash", "1.0.0")]
    [Description("Everything about server chat messages.")]
    public class ServerMessages : RustPlugin
    {
        #region Configuration

        private ConfigData config;

        public class ConfigData
        {
            [JsonProperty(PropertyName = "Chat Icon (SteamID64)")]
            public ulong ChatIcon { get; set; }

            [JsonProperty(PropertyName = "Block 'gave' Commands (true/false)")]
            public bool BlockGaveCommands { get; set; }

            [JsonProperty(PropertyName = "Message Formatting")]
            public MessageFormat Format { get; set; }
        }

        public class MessageFormat
        {
            [JsonProperty(PropertyName = "Title")]
            public string Title { get; set; }

            [JsonProperty(PropertyName = "Title Color")]
            public string TitleColor { get; set; }

            [JsonProperty(PropertyName = "Title Size")]
            public int TitleSize { get; set; }

            [JsonProperty(PropertyName = "Message Color")]
            public string MessageColor { get; set; }

            [JsonProperty(PropertyName = "Message Size")]
            public int MessageSize { get; set; }

            [JsonProperty(PropertyName = "Chat Format")]
            public string ChatFormat { get; set; }
        }

        protected override void LoadConfig()
        {
            base.LoadConfig();
            try
            {
                config = Config.ReadObject<ConfigData>();
                if (config == null)
                {
                    throw new System.Exception("Config is null");
                }
            }
            catch (Exception ex)
            {
                PrintError($"Configuration error: {ex.Message}");
                LoadDefaultConfig();
            }
            SaveConfig();
        }

        protected override void LoadDefaultConfig()
        {
            config = new ConfigData
            {
                ChatIcon = 0,
                BlockGaveCommands = true,
                Format = new MessageFormat
                {
                    Title = "ServerName",
                    TitleColor = "#FFED00",
                    TitleSize = 15,
                    MessageColor = "#FFFFFF",
                    MessageSize = 15,
                    ChatFormat = "{title}: {message}"
                }
            };
        }

        protected override void SaveConfig() => Config.WriteObject(config);

        #endregion

        #region Hooks

        private object OnServerMessage(string message, string name)
        {
            if (string.IsNullOrEmpty(message) || string.IsNullOrEmpty(name))
                return null;

            if (name != "SERVER")
                return null;

            return ShouldBlockMessage(message) ? true : null;
        }

        private object OnServerCommand(ConsoleSystem.Arg arg)
        {
            if (arg?.cmd == null || string.IsNullOrEmpty(arg.cmd.FullName))
                return null;

            if (arg.cmd.FullName != "global.say" || arg.Args == null || arg.Args.Length == 0)
                return null;

            string message = string.Join(" ", arg.Args).Trim();

            // Check if message should be blocked
            if (ShouldBlockMessage(message))
                return false;

            // Format and broadcast the message
            string formattedMessage = FormatMessage(message);
            Server.Broadcast(formattedMessage, config.ChatIcon);

            return false; // Block default message
        }

        #endregion

        #region Helper Methods

        private bool ShouldBlockMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
                return false;

            // Check gave commands
            if (config.BlockGaveCommands && message.ToLower().Contains("gave"))
                return true;

            return false;
        }

        private string FormatMessage(string message)
        {
            string title = $"<size={config.Format.TitleSize}><color={config.Format.TitleColor}>{config.Format.Title}</color></size>";
            string formattedMessage = $"<size={config.Format.MessageSize}><color={config.Format.MessageColor}>{message}</color></size>";

            return config.Format.ChatFormat
                .Replace("{title}", title)
                .Replace("{message}", formattedMessage);
        }

        #endregion
    }
}