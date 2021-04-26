using Sampath.SMSB.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Services.Interfaces
{
    public interface IMessageProcessorService
    {
        void ProceessMessage(InQue message);
    }
}
