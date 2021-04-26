using Sampath.SMSB.Services.Handlers.Interfaces;
using Sampath.SMSB.Services.Interfaces;
using Sampath.SMSB.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Services.Handlers.MessageHandlers
{
    public class ChangePasswordHandler : Handler<Message>, IChangePasswordHandler
    {
        private readonly IChangePasswordService _changePasswordService;

        public ChangePasswordHandler(IChangePasswordService changePasswordService)
        {
            _changePasswordService = changePasswordService;
        }

        public override void Handle(Message message)
        {
            _changePasswordService.printMessage();
             base.Handle(message);
        }
    }
}
