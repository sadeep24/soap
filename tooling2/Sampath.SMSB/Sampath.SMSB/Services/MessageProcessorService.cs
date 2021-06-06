using Common;
using log4net;
using Sampath.SMSB.Infrastructure.Models;
using Sampath.SMSB.Infrastructure.SignalR;
using Sampath.SMSB.Services.Handlers;
using Sampath.SMSB.Services.Handlers.Interfaces;
using Sampath.SMSB.Services.Handlers.MessageHandlers;
using Sampath.SMSB.Services.Interfaces;
using Sampath.SMSB.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Services
{
    public class MessageProcessorService : IMessageProcessorService
    {
        private readonly IBalanceInqueryHandler _balanceInqueryHandler;
        private readonly IBillPaymentHandler _billPaymentHandler;
        private readonly IChangePasswordHandler _changePasswordHandler;
        private readonly ICreditCardBalanceInquiryHandler _creditCardBalanceInquiryHandler;
        private readonly IInquireChequeStatusHandler _inquireChequeStatusHandler;
        private readonly IMiniStatementHandler _miniStatementHandler;
        private readonly IMissedCallReloadHandler _missedCallReloadHandler;
        private readonly IReloadUsingDefaultAccountHandler _reloadUsingDefaultAccountHandler;
        private readonly IReloadUsingSpecificAccount _reloadUsingSpecificAccount;
        private readonly ISettleCreditCardOutstandingBalanceHandler _settleCreditCardOutstandingBalanceHandler;
        private readonly ISLTReloadBillPaymentHandler _sltReloadBillPaymentHandler;
        private readonly IStopChequeHandler _stopChequeHandler;
        private readonly ITransferToOwnAccountHandler _transferToOwnAccountHandler;
        private readonly ITransferToOtherBankAccountHandler _transferToOtherBankAccountHandler;
        private readonly ITransferToOtherSampathAccountHandller _transferToOtherSampathAccountHandller;

        public MessageProcessorService(IBalanceInqueryHandler balanceInqueryHandler, IBillPaymentHandler billPaymentHandler, IChangePasswordHandler changePasswordHandler
            ,ICreditCardBalanceInquiryHandler creditCardBalanceInquiryHandler, IInquireChequeStatusHandler inquireChequeStatusHandler, IMiniStatementHandler miniStatementHandler
            ,IMissedCallReloadHandler missedCallReloadHandler, IReloadUsingDefaultAccountHandler reloadUsingDefaultAccountHandler, IReloadUsingSpecificAccount reloadUsingSpecificAccount
            , ISettleCreditCardOutstandingBalanceHandler settleCreditCardOutstandingBalanceHandler, ISLTReloadBillPaymentHandler sltReloadBillPaymentHandler, IStopChequeHandler stopChequeHandler
            , ITransferToOwnAccountHandler transferToOwnAccountHandler, ITransferToOtherBankAccountHandler transferToOtherBankAccountHandler,
            ITransferToOtherSampathAccountHandller transferToOtherSampathAccountHandller)
        {
            _balanceInqueryHandler = balanceInqueryHandler;
            _billPaymentHandler = billPaymentHandler;
            _changePasswordHandler = changePasswordHandler;
            _creditCardBalanceInquiryHandler = creditCardBalanceInquiryHandler;
            _inquireChequeStatusHandler = inquireChequeStatusHandler;
            _miniStatementHandler = miniStatementHandler;
            _missedCallReloadHandler = missedCallReloadHandler;
            _reloadUsingDefaultAccountHandler = reloadUsingDefaultAccountHandler;
            _reloadUsingSpecificAccount = reloadUsingSpecificAccount;
            _settleCreditCardOutstandingBalanceHandler = settleCreditCardOutstandingBalanceHandler;
            _sltReloadBillPaymentHandler = sltReloadBillPaymentHandler;
            _stopChequeHandler = stopChequeHandler;
            _transferToOwnAccountHandler = transferToOwnAccountHandler;
            _transferToOtherBankAccountHandler = transferToOtherBankAccountHandler;
            _transferToOtherSampathAccountHandller = transferToOtherSampathAccountHandller;
        }

        public void ProceessMessage(InQue inQueItem)
        {
            var decrypteMessage= SMSEncryptor.Decrypt(inQueItem.Inq_Inrec);
            var message = new Message();
            if (decrypteMessage.Length > 39)
            {
                
                message.Conn_Code = inQueItem.Inq_Payee_Code;
                message.Session_Id = inQueItem.Session_Id;
                message.Card_Seq_No = inQueItem.Inq_Card_Seq_No;
                message.Card_Mode = inQueItem.Inq_Card_Mode;
                message.MessageContent = decrypteMessage.Substring(38);
                message.TxnId = decrypteMessage.Substring(5, 6);
                message.MSISDN = decrypteMessage.Substring(11, 15);
                message.DateTime = decrypteMessage.Substring(26, 12);
                message.DateOfDB = inQueItem.DATEOFDB;
                message.Header = decrypteMessage.Substring(0, 5);
            }

            var handler = (IHandler<Message>)_balanceInqueryHandler;
           
            handler.SetNext((IHandler<Message>)_billPaymentHandler).SetNext((IHandler<Message>)_changePasswordHandler)
                .SetNext((IHandler<Message>)_creditCardBalanceInquiryHandler).SetNext((IHandler<Message>)_inquireChequeStatusHandler).SetNext((IHandler<Message>)_miniStatementHandler)
                .SetNext((IHandler<Message>)_missedCallReloadHandler).SetNext((IHandler<Message>)_reloadUsingDefaultAccountHandler).SetNext((IHandler<Message>)_reloadUsingSpecificAccount)
                .SetNext((IHandler<Message>)_settleCreditCardOutstandingBalanceHandler).SetNext((IHandler<Message>)_sltReloadBillPaymentHandler).SetNext((IHandler<Message>)_stopChequeHandler)
                .SetNext((IHandler<Message>)_transferToOtherBankAccountHandler).SetNext((IHandler<Message>)_transferToOtherSampathAccountHandller).SetNext((IHandler<Message>)_transferToOwnAccountHandler)
                .SetNext((IHandler<Message>)_transferToOwnAccountHandler);
            handler.Handle(message);
            
        }
    }
}
