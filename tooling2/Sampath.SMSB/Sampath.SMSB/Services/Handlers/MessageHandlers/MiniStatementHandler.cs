using Sampath.SMSB.Services.Handlers.Interfaces;
using Sampath.SMSB.Services.Interfaces;
using Sampath.SMSB.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Services.Handlers.MessageHandlers
{
    public class MiniStatementHandler : Handler<Message>, IMiniStatementHandler
    {
        private readonly IMiniStatementService _miniStatementService;

        public MiniStatementHandler(IMiniStatementService miniStatementService)
        {
            _miniStatementService = miniStatementService;
        }

        public override void Handle(Message message)
        {
            _miniStatementService.printMessage();
            base.Handle(message);
        }
    }
}
