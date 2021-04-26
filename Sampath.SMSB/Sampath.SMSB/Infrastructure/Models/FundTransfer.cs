using System;
using System.Collections.Generic;

namespace Sampath.SMSB.Infrastructure.Models
{
    public class FundTransfer
    {
        public string TfrCusno { get; set; }
        public bool? TfrFlag { get; set; }
        public byte? TfrUtcode { get; set; }
        public byte? TfrRefCode { get; set; }
        public string TfrAccFrom { get; set; }
        public string TfrAccTo { get; set; }
        public string TfrToBank { get; set; }
        public string TfrToBranch { get; set; }
        public string TfrLimit { get; set; }
        public string TfrReference { get; set; }
        public string TfrName { get; set; }
        public string TfrCmpName { get; set; }
    }
}
