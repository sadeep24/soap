using System;
using System.Collections.Generic;

namespace Sampath.SMSB.Infrastructure.Models
{
    public class OutQue
    {
        public string OuqOutrec { get; set; }
        public string OuqProcessed { get; set; }
        public string OuqPayeeCode { get; set; }
        public string SessionId { get; set; }
        public string OuqPriority { get; set; }
        public string OuqCardSeqNo { get; set; }
        public string OuqCardMode { get; set; }
        public string DeliveryStatus { get; set; }
        public string OuqToinbox { get; set; }
        public DateTime? OuqMsgDate { get; set; }
        public string OuqCustId { get; set; }
        public int? OuqSeqNo { get; set; }
        public string OuqCustName { get; set; }
        public string OuqTranRemarks { get; set; }
        public string OuqDiaReceiptNo { get; set; }
        public string OuqTelNumber { get; set; }
        public int? OuqSeq { get; set; }
        public DateTime? OuqMsgSentDate { get; set; }
    }
}
