using Sampath.SMSB.Services.Handlers.Interfaces;
using Sampath.SMSB.Services.Interfaces;
using Sampath.SMSB.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Services.Handlers.MessageHandlers
{
    public class TransferToOwnAccountHandler : Handler<Message>, ITransferToOwnAccountHandler
    {
        private readonly ITransferToOwnAccountService _transferToOwnAccountService;

        public TransferToOwnAccountHandler(ITransferToOwnAccountService transferToOwnAccountService)
        {
            _transferToOwnAccountService = transferToOwnAccountService;
        }

        public override void Handle(Message message)
        {
            // base.Handle(message);
        }
    }
}
