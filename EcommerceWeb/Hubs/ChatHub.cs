using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace EcommerceWeb.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            System.Diagnostics.Debug.WriteLine("Connection ID: " + Context.ConnectionId);
            //Clients.All.addNewMessageToPage(name, message);
            Clients.Client("1bfa96be-843c-4945-8149-8ebdee8f75de").SendAsync(name, message);
        }
    }
}
