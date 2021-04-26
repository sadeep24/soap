using System;
using System.Collections.Generic;

namespace Sampath.SMSB.Infrastructure.Models
{
    public class Transaction
    {
        public string Tbno { get; set; }
        public string CardSeqNo { get; set; }
        public string TxnId { get; set; }
        public string MobileNo { get; set; }
        public DateTime? DateTime { get; set; }
        public string IncomingMsg { get; set; }
        public string ReplyMsg { get; set; }
        public string TranType { get; set; }
        public string AccAccNo { get; set; }
        public string AccAccCode { get; set; }
        public decimal? AccBal { get; set; }
        public string DebitAccCode { get; set; }
        public string DebitAccNo { get; set; }
        public string CreditAccCode { get; set; }
        public string CreditAccNo { get; set; }
        public decimal? TfrAmount { get; set; }
        public string TfrFundSeqNo { get; set; }
        public string TfrToBank { get; set; }
        public string TfrToBranch { get; set; }
        public string Reference { get; set; }
        public string RefNoAuthCode { get; set; }
        public string TfrName { get; set; }
        public string CreditCardCode { get; set; }
        public string CreditCardNo { get; set; }
        public string MerchantId { get; set; }
        public string InvoiceNo { get; set; }
        public string PhoneNo { get; set; }
        public string SalesmenMobileNo { get; set; }
        public string RevenueLicenceNo { get; set; }
        public string VehicleRegNo { get; set; }
        public string ChassisNo { get; set; }
        public string GreenTest { get; set; }
        public string InsurenceComp { get; set; }
        public string ChequeNo { get; set; }
        public string ChequeStatus { get; set; }
        public string Remark1 { get; set; }
        public string Remark2 { get; set; }
        public decimal? SeqNo { get; set; }
        public string ConnCode { get; set; }
        public DateTime? DateTimeDb { get; set; }
        public string Status { get; set; }
    }
}
