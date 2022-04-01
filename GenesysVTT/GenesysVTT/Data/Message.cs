using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace GenesysVTT.Data
{
    public class Message
    {
        public Message(string username, string body, bool mine)
        {
            Username = username;
            Body = body;
            Mine = mine;
            Timestamp = DateTime.Now;
        }
        public string Username { get; set; }
        public string Body { get; set; }
        public bool Mine { get; set; }
        public bool IsNotice => Body.StartsWith("[Notice]");
        public bool IsDiceResult => Body.StartsWith("[Dice]");
        public string CSS => Mine ? "sent" : "received";
        public MessageLogType Type { get; set; }
        public DateTime Timestamp { get; set; }

    }

    public enum MessageLogType
    {
        DiceResult,
        StoryPoint,
        Chat,
    }
}
