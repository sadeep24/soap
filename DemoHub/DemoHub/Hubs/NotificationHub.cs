using ConsoleSignalRClient;
using DemoHub.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoHub.Hubs
{
    public class NotificationHub:Hub
    {
        //public async Task SendMessage()
        //{
        //    await Clients.All.SendAsync("SignalMessageReceived");
        //}
        public async Task SendMessage(TransactionDetails transactionDetails)
        {
            await Clients.All.SendAsync("SignalMessageReceived", transactionDetails);
        }
    }
}
