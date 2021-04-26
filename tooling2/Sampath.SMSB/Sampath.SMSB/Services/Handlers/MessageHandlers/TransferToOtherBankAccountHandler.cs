using Sampath.SMSB.Services.Handlers.Interfaces;
using Sampath.SMSB.Services.Interfaces;
using Sampath.SMSB.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Services.Handlers.MessageHandlers
{
    public class TransferToOtherBankAccountHandler : Handler<Message>, ITransferToOtherBankAccountHandler
    {
        private readonly ITransferToOtherBankAccountService _transferToOtherBankAccountService;

        public TransferToOtherBankAccountHandler(ITransferToOtherBankAccountService transferToOtherBankAccountService)
        {
            _transferToOtherBankAccountService = transferToOtherBankAccountService;
        }

        public override void Handle(Message message)
        {
            // base.Handle(message);
        }
    }
}
