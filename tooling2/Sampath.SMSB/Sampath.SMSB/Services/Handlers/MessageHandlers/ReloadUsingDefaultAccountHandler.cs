using Sampath.SMSB.Services.Handlers.Interfaces;
using Sampath.SMSB.Services.Interfaces;
using Sampath.SMSB.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Services.Handlers.MessageHandlers
{
    public class ReloadUsingDefaultAccountHandler : Handler<Message>, IReloadUsingDefaultAccountHandler
    {
        private readonly IReloadUsingDefaultAccountService _reloadUsingDefaultAccountService;

        public ReloadUsingDefaultAccountHandler(IReloadUsingDefaultAccountService reloadUsingDefaultAccountService)
        {
            _reloadUsingDefaultAccountService = reloadUsingDefaultAccountService;
        }

        public override void Handle(Message message)
        {
            _reloadUsingDefaultAccountService.printMessage();
            base.Handle(message);
        }
    }
}
