using Sampath.SMSB.Infrastructure.Models;
using Sampath.SMSB.Services.Handlers.Interfaces;
using Sampath.SMSB.Services.Interfaces;
using Sampath.SMSB.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Services.Handlers.MessageHandlers
{
    public class BalanceInqueryHandler : Handler<Message>, IBalanceInqueryHandler
    {
        private readonly IBalanceInquiryService _balanceInquiryService;


        public BalanceInqueryHandler(IBalanceInquiryService balanceInquiryService)
        {
            _balanceInquiryService = balanceInquiryService;
        }

        public override void Handle(Message message)
        {
            _balanceInquiryService.printMessage();
            base.Handle(message);
        }
    }
}
