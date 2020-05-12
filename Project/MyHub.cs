using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Project
{
    public class MyHub : Hub
    {
        public void SendMessage(string message)
        {
            
            Clients.All.MessageReceived(message);
        }
    }
}