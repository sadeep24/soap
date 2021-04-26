using Sampath.SMSB.Services.Handlers.Interfaces;
using Sampath.SMSB.Services.Interfaces;
using Sampath.SMSB.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Services.Handlers.MessageHandlers
{
    public class MissedCallReloadHandler : Handler<Message>, IMissedCallReloadHandler
    {
        private readonly IMissedCallReloadService _missedCallReloadService;

        public MissedCallReloadHandler(IMissedCallReloadService missedCallReloadService)
        {
            _missedCallReloadService = missedCallReloadService;
        }

        public override void Handle(Message message)
        {
            _missedCallReloadService.printMessage();
            base.Handle(message);
        }
    }
}
