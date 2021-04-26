using Sampath.SMSB.Services.Handlers.Interfaces;
using Sampath.SMSB.Services.Interfaces;
using Sampath.SMSB.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Services.Handlers.MessageHandlers
{
    public class SLTReloadBillPaymentHandler : Handler<Message>, ISLTReloadBillPaymentHandler
    {
        private readonly IChangePasswordService _changePasswordService;

        public SLTReloadBillPaymentHandler(IChangePasswordService changePasswordService)
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
