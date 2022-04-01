using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using GenesysVTT.Data;

namespace GenesysVTT.Services
{
    public class ChatHub : Hub
    {

        public const string HubUrl = "/chat";

        //private readonly GenesysVTTContext _context;
        //public ChatHub(GenesysVTTContext context)
        //{
        //    _context = context;
        //}

        public async Task Broadcast(string username, string message)
        {
            await Clients.All.SendAsync("Broadcast", username, message);
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnConnectedAsync();
        }
    }
}
