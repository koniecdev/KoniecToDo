using Microsoft.AspNetCore.SignalR;

namespace Infrastructure;
public class NotificationHub : Hub
{
    public async Task SendNotification(string message, string id)
    {
        await Clients.All.SendAsync("ReceiveNotification", message, id);
    }
}