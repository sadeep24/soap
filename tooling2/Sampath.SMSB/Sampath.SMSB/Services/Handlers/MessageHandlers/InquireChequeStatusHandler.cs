using Sampath.SMSB.Services.Handlers.Interfaces;
using Sampath.SMSB.Services.Interfaces;
using Sampath.SMSB.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Services.Handlers.MessageHandlers
{
    public class InquireChequeStatusHandler : Handler<Message>, IInquireChequeStatusHandler
    {
        private readonly IInquireChequeStatusService _inquireChequeStatus;

        public InquireChequeStatusHandler(IInquireChequeStatusService inquireChequeStatus)
        {
            _inquireChequeStatus = inquireChequeStatus;
        }

        public override void Handle(Message message)
        {
            _inquireChequeStatus.printMessage();
            base.Handle(message);
        }
    }
}
