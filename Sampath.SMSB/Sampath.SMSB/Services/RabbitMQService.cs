using Common;
using EventBusRabbitMQ;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Sampath.SMSB.Infrastructure.EventBus.Common;
using Sampath.SMSB.Infrastructure.Models;
using Sampath.SMSB.Infrastructure.Repositories.Interfeaces;
using Sampath.SMSB.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sampath.SMSB.Services
{
    public class RabbitMQService: IRabbitMQService
    {
        private readonly IRabbitMQConnection _connection;
        private readonly IInQueRepository _inQueRepository;
        public RabbitMQService(IRabbitMQConnection connection, IInQueRepository inQueRepository)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
            _inQueRepository = inQueRepository;



        }

        public void Send()
        {
            try
            {
                var messages = _inQueRepository.GetAllProducts();
                if (messages != null)
                {
                    using (var channel = _connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: "task_queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

                        //var message = JsonConvert.SerializeObject(new Sm { Id = 1, AccAccCode = "344355", AccAccNo = "2324244", AccTelbankNo = "2435466" });
                        // var body = Encoding.UTF8.GetBytes(message);

                        var properties = channel.CreateBasicProperties();
                        properties.Persistent = true;

                        foreach (InQue message in messages.Result.ToArray())
                        {
                            var messagestr = JsonConvert.SerializeObject(message);
                            var body = Encoding.UTF8.GetBytes(messagestr);
                            channel.BasicPublish(exchange: "", routingKey: "task_queue", basicProperties: properties, body: body);

                        }

                        Console.ReadLine();
                    }
                }
            }
            catch(Exception ex)
            {
                var t = ex.GetType().Name;
            }
           
             
           
              
           
          
        }

        public void Disconnect()
        {
            _connection.Dispose();
        }
    }
}
