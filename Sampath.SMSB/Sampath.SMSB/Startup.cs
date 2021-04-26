using Sampath.SMSB.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.ConsoleApp
{
    public class Startup
    {
        private readonly IRabbitMQService _rabbitMQService;
        public Startup(IRabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }

        // Application starting point
        public void Run()
        {
            _rabbitMQService.Send();
        }
    }
}
