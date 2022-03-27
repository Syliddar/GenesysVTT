using System.ComponentModel.DataAnnotations;

namespace GenesysVTT.Data
{
    public class MessageLog
    {
        public MessageLog()
        {
            Message = "";
            UserName = "";
        }
        [Key]
        public Guid Id { get; set; }
        public MessageLogType Type { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }

        [MaxLength(250)]
        public string UserName { get; set; }

    }

    public enum MessageLogType
    {
        DiceResult,
        StoryPoint,
        Chat,
    }
}
