using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Infrastructure.SignalR
{
    public class SignalRConnection
    {
        private HubConnection hubConnection;
        public SignalRConnection()
        {


            hubConnection = new HubConnectionBuilder()
               .WithUrl("http://localhost:59539/notification")
               .Build();
            var t = hubConnection.StartAsync();

            t.Wait();

        }
        public void sendPortal()
        {
   
            hubConnection.InvokeAsync("SendMessage");
        }

    }
}
