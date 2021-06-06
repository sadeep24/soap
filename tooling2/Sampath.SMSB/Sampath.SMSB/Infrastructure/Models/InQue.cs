using System;
using System.Collections.Generic;

namespace Sampath.SMSB.Infrastructure.Models
{
    public class InQue
    {
        public string Inq_Inrec { get; set; }
        public string Inq_Processed { get; set; }
        public string Inq_Payee_Code { get; set; }
        public string Session_Id { get; set; }
        public string Inq_Card_Seq_No { get; set; }
        public string Inq_Card_Mode { get; set; }
        public string Inq_Segment { get; set; }
        public string Inq_Bkp { get; set; }
        public string Inq_Channel { get; set; }
        public string Inq_Date { get; set; }
        public string DATEOFDB { get; set; }
        public string Inq_Tel_Number { get; set; }
    }
}
