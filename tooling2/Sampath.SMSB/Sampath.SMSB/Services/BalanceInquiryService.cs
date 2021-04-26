using Sampath.SMSB.Infrastructure.Models;
using Sampath.SMSB.Infrastructure.Repositories.Interfeaces;
using Sampath.SMSB.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Services
{
    public class BalanceInquiryService : IBalanceInquiryService
    {
        private readonly IOutQueRepository _outQueRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ISMSMTNRepository _sMSMTNRepository;
        private readonly ILoggerService _logger;

        public BalanceInquiryService(IOutQueRepository outQueRepository,ILoggerService logger, ITransactionRepository transactionRepository, ISMSMTNRepository sMSMTNRepository)
        {
            _outQueRepository = outQueRepository;
            _logger = logger;
            _transactionRepository = transactionRepository;
            _sMSMTNRepository = sMSMTNRepository;
        }

        public async void printMessage()
        {
            var outq = new OutQue();
         
            outq.Ouq_Processed = "Y";
            outq.Ouq_Payee_Code = "xxx";
            outq.Session_Id = "sdfdsfsdg";
            outq.Ouq_Priority = "s";
            outq.Ouq_Card_Seq_No = "sdfdsfsdg";
            outq.Ouq_Card_Mode = "Normal";
            outq.Delivery_Status = "sdfdsfsdg";
            outq.Ouq_Toinbox = "s";
            outq.Ouq_Cust_Id = "sdfdsfsdg";
            outq.Ouq_Seq_No = 2;
            outq.Ouq_Cust_Name = "sdfdsfsdg";
            outq.Ouq_Tran_Remarks = "sdfdsfsdg";
            outq.Ouq_Dia_Receipt_No = "eee";
            outq.Ouq_Tel_Number = "sdfdsfsdg";
            outq.Ouq_Seq = 4;
             _logger.LogAllSMSBTxns("Hello");
            await _outQueRepository.InsertOutQue(outq);
            var tran = new Transaction();
            tran.Acc_Acc_Code = "sa";
            await _transactionRepository.InsertTansaction(tran);
           // Smsmtn test = await _sMSMTNRepository.GetTeleBankingDetails(772467046);
            Console.WriteLine("BalanceInquiryService");
        }
    }
}
