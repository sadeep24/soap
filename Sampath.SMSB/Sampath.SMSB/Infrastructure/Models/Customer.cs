using System;
using System.Collections.Generic;

namespace Sampath.SMSB.Infrastructure.Models
{
    public class Customer
    {
        public string CustTelbankNo { get; set; }
        public string CustCustName { get; set; }
        public string CustTpinNo { get; set; }
        public string CustStartDate { get; set; }
        public string CustDelegateFlag { get; set; }
        public string CustStatus { get; set; }
        public string CustTfrFlag { get; set; }
        public bool? CustPinAtt { get; set; }
        public string CustStmtFlag { get; set; }
        public string CustChqbsFlag { get; set; }
        public string CustBalenqFlag { get; set; }
        public string CustFaxNo { get; set; }
        public string CustHomeAddress { get; set; }
        public string CustHomePhone { get; set; }
        public string CustOffAddress { get; set; }
        public string CustOffPhone { get; set; }
        public string CustPassNo { get; set; }
        public string CustOccupation { get; set; }
    }
}
