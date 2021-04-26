using System;
using System.Collections.Generic;

namespace Sampath.SMSB.Infrastructure.Models
{
    public class Smsmtn
    {
        public string Smsphoneno { get; set; }
        public string Smstelbankno { get; set; }
        public string Smsstatus { get; set; }
        public string SmsstartDate { get; set; }
        public string SmsmodifiedDate { get; set; }
        public bool? SmsRetryCount { get; set; }
        public string SmsSimCardNo { get; set; }
        public string SmsLastPhoneno { get; set; }
        public string SmsCreatedUserId { get; set; }
        public DateTime? SmsCreatedDate { get; set; }
        public string SmsCreatedSol { get; set; }
        public string SmsAuthorizedUserId { get; set; }
        public DateTime? SmsAuthorizedDate { get; set; }
        public string SmsAuthorizedSol { get; set; }
        public string SmsCanvasType { get; set; }
        public string SmsCanvasDesc { get; set; }
        public DateTime? SmsCanvasDate { get; set; }
    }
}
