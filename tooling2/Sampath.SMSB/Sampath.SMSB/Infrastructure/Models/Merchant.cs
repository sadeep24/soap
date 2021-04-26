using System;
using System.Collections.Generic;

namespace Sampath.SMSB.Infrastructure.Models
{
    public class Merchant
    {
        public byte? MerSrlNo { get; set; }
        public string MerPayeeId { get; set; }
        public string MerPayeeName { get; set; }
        public string MerAddress { get; set; }
        public string MerField1Enabled { get; set; }
        public string MerField2Enabled { get; set; }
        public string MerField3Enabled { get; set; }
        public string MerField4Enabled { get; set; }
        public string MerField5Enabled { get; set; }
        public string MerField1Desc { get; set; }
        public string MerField2Desc { get; set; }
        public string MerField3Desc { get; set; }
        public string MerField4Desc { get; set; }
        public string MerField5Desc { get; set; }
        public string MerCollAcc { get; set; }
        public string MerPayeeCode { get; set; }
        public bool? MerSmsbReqFields { get; set; }
        public string MerSmsbF1Type { get; set; }
        public byte? MerSmsbF1Size { get; set; }
        public string MerSmsbF2Type { get; set; }
        public byte? MerSmsbF2Size { get; set; }
        public decimal? MerSmsbTranLimit { get; set; }
        public string MerCcMerchantComm { get; set; }
        public decimal? MerRldMinLimit { get; set; }
        public decimal? MerRldDailyLimit { get; set; }
    }
}
