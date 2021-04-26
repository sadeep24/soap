using Sampath.SMSB.Services.Handlers.Interfaces;
using Sampath.SMSB.Services.Interfaces;
using Sampath.SMSB.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Services.Handlers.MessageHandlers
{
    public class ReloadUsingSpecificAccountHandler : Handler<Message>, IReloadUsingSpecificAccount
    {
        private readonly IReloadUsingSpecificAccountService _reloadUsingSpecificAccountService;

        public ReloadUsingSpecificAccountHandler(IReloadUsingSpecificAccountService reloadUsingSpecificAccountService)
        {
            _reloadUsingSpecificAccountService = reloadUsingSpecificAccountService;
        }

        public override void Handle(Message message)
        {
            _reloadUsingSpecificAccountService.printMessage();
            base.Handle(message);
        }
    }
}
