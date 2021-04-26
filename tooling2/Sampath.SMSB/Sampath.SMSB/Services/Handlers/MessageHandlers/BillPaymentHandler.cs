using Sampath.SMSB.Services.Handlers.Interfaces;
using Sampath.SMSB.Services.Interfaces;
using Sampath.SMSB.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Services.Handlers.MessageHandlers
{
    public class BillPaymentHandler : Handler<Message>, IBillPaymentHandler
    {
        private readonly IBillPaymentService _billPaymentService;

        public BillPaymentHandler(IBillPaymentService billPaymentService)
        {
            _billPaymentService = billPaymentService;
        }

        public override void Handle(Message message)
        {
            _billPaymentService.printMessage();
             base.Handle(message);
        }
    }
}
