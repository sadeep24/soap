using DemoHub.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace ConsoleSignalRClient
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            HubConnection connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:59539/notification")
                .Build();
            await connection.StartAsync();
            try
            {
                connection.On<TransactionDetails>("SignalMessageReceived", (transactionDetails) =>
                {
                    Console.WriteLine(transactionDetails.Tran_Type);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            while (true)
            {

                string key = Console.ReadLine();
                if (key.ToUpper() == "S")
                {
                    try
                    {
                        await connection.InvokeAsync("SendMessage");
                        //await connection.o
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
