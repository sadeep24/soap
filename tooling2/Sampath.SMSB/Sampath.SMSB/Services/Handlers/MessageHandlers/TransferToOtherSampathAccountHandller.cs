using Sampath.SMSB.Services.Handlers.Interfaces;
using Sampath.SMSB.Services.Interfaces;
using Sampath.SMSB.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Services.Handlers.MessageHandlers
{
    public class TransferToOtherSampathAccountHandller : Handler<Message>, ITransferToOtherSampathAccountHandller
    {
        private readonly ITransferToOtherSampathAccountService _transferToOtherSampathAccountService;

        public TransferToOtherSampathAccountHandller(ITransferToOtherSampathAccountService transferToOtherSampathAccountService)
        {
            _transferToOtherSampathAccountService = transferToOtherSampathAccountService;
        }

        public override void Handle(Message message)
        {
            // base.Handle(message);
        }
    }
}
