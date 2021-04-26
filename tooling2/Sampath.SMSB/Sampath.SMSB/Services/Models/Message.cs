using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Services.Models
{
    public class Message
    {

        public string Header { get; set; }
        public string TxnId { get; set; }
        public string MSISDN { get; set; }
        public string DateTime { get; set; }
        public string MessageContent { get; set; }
        public string Conn_Code { get; set; }
        public string Session_Id { get; set; }
        public string Card_Seq_No { get; set; }
        public string Card_Mode { get; set; }
        public string DateOfDB { get; set; }
        public string Reply { get; set; }
    }
}
