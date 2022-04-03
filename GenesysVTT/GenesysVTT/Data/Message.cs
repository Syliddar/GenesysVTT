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

            try
            {
                var resultJson = JsonSerializer.Deserialize<ResultJson>(Body);
                if (resultJson != null)
                {
                    IsDiceResult = true;
                    Data = new Dictionary<string, string>
                    {
                        { "Result", resultJson.Result },
                        { "Pool", resultJson.Pool }
                    };
                }
            }
            catch
            {
                IsDiceResult = false;
            }
        }
        public string Username { get; set; }
        public string Body { get; set; }
        public Dictionary<string, string> Data { get; set; }
        public bool Mine { get; set; }
        public bool IsNotice { get; set; }
        public bool IsDiceResult { get; set; }
        public string CSS => Mine ? "sent" : "received";
        public DateTime Timestamp { get; set; }
    }
}
