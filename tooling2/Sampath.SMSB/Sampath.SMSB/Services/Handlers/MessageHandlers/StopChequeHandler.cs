using Sampath.SMSB.Services.Handlers.Interfaces;
using Sampath.SMSB.Services.Interfaces;
using Sampath.SMSB.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Services.Handlers.MessageHandlers
{
    public class StopChequeHandler : Handler<Message>, IStopChequeHandler
    {
        private readonly IStopChequeService _stopChequeService;

        public StopChequeHandler(IStopChequeService stopChequeService)
        {
            _stopChequeService = stopChequeService;
        }

        public override void Handle(Message message)
        {
            _stopChequeService.printMessage();
             base.Handle(message);
        }
    }
}
