using GenesysVTT.Data;

namespace GenesysVTT.Services
{
    public class MessageLogService
    {
        private readonly GenesysVTTContext _context;

        public MessageLogService(GenesysVTTContext context)
        {
            _context = context;
        }

        public Task<List<MessageLog>> GetMessagesAsync()
        {
            return Task.FromResult(_context.MessageLogs.Take(1000).ToList());
        }
    }
}
