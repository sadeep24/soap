using System;
using System.Collections.Generic;

namespace Sampath.SMSB.Infrastructure.Models
{
    public class Customer
    {
        public string Cust_Telbank_No { get; set; }
        public string Cust_Cust_Name { get; set; }
        public string Cust_Tpin_No { get; set; }
        public string Cust_Start_Date { get; set; }
        public string Cust_Delegate_Flag { get; set; }
        public string Cust_Status { get; set; }
        public string Cust_Tfr_Flag { get; set; }
        public bool? Cust_Pin_Att { get; set; }
        public string Cust_Stmt_Flag { get; set; }
        public string Cust_Chqbs_Flag { get; set; }
        public string Cust_Balenq_Flag { get; set; }
        public string Cust_Fax_No { get; set; }
        public string Cust_Home_Address { get; set; }
        public string Cust_Home_Phone { get; set; }
        public string Cust_Off_Address { get; set; }
        public string Cust_Off_Phone { get; set; }
        public string Cust_Pass_No { get; set; }
        public string Cust_Occupation { get; set; }
    }
}
