using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Services.Interfaces
{
    public interface IRabbitMQService
    {
        void Consume();
        void Disconnect();

    }
}
