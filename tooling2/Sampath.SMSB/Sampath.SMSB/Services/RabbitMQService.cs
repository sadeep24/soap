using Common;
using EventBusRabbitMQ;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Sampath.SMSB.Infrastructure.EventBus.Common;
using Sampath.SMSB.Infrastructure.Models;
using Sampath.SMSB.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sampath.SMSB.Services
{
    public class RabbitMQService: IRabbitMQService
    {
        private readonly IRabbitMQConnection _connection;
        private readonly IMessageProcessorService _messageProcessorService;
        private readonly ILoggerService _logger;
        public RabbitMQService(IRabbitMQConnection connection, IMessageProcessorService messageProcessorService, ILoggerService logger)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
            _messageProcessorService = messageProcessorService;
            _logger = logger;
        }

        public void Consume()
        {
            // _logger.LogCDCIError("test log");
            using (var channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queue: EventBusConstants.SmsQue, durable: true, exclusive: false, autoDelete: false, arguments: null);

                channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                Console.WriteLine(" [*] Waiting for messages.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += ReceivedEvent;
                channel.BasicConsume(queue: EventBusConstants.SmsQue, autoAck: false, consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }

        public void Disconnect()
        {
            _connection.Dispose();
        }
        private void ReceivedEvent(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var inqueMessage = (InQue)JsonConvert.DeserializeObject<InQue>(message);
            _messageProcessorService.ProceessMessage(inqueMessage);
            Thread.Sleep(10);
            ((EventingBasicConsumer)sender).Model.BasicAck(deliveryTag: e.DeliveryTag, multiple: false);
        }
    }
}
