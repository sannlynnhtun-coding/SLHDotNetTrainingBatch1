using Microsoft.AspNetCore.SignalR;

namespace SLHDotNetTrainingBatch1.SignalrExample.Hubs
{
    public class ChatHub : Hub
    {
        // server event / listener
        // send message
        public async Task ServerReceiveMessage(string user, string message)
        {
            // ReceiveMessage => event
            await Clients.AllExcept(Context.ConnectionId).SendAsync("ClientReceiveMessage", user, message);
        }
    }
}
