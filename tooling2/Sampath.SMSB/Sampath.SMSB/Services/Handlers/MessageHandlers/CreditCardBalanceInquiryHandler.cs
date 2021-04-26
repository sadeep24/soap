using Sampath.SMSB.Services.Handlers.Interfaces;
using Sampath.SMSB.Services.Interfaces;
using Sampath.SMSB.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Services.Handlers.MessageHandlers
{
    public class CreditCardBalanceInquiryHandler : Handler<Message>, ICreditCardBalanceInquiryHandler
    {
        private readonly ICreditCardBalanceInquiryService _creditCardBalanceInquiryService;

        public CreditCardBalanceInquiryHandler(ICreditCardBalanceInquiryService creditCardBalanceInquiryService)
        {
            _creditCardBalanceInquiryService = creditCardBalanceInquiryService;
        }

        public override void Handle(Message message)
        {
            _creditCardBalanceInquiryService.printMessage();
             base.Handle(message);
        }
    }
}
