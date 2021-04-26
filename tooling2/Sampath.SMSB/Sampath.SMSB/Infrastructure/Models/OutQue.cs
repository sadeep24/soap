using System;
using System.Collections.Generic;

namespace Sampath.SMSB.Infrastructure.Models
{
    public class OutQue
    {
        public string Ouq_Outrec { get; set; }
        public string Ouq_Processed { get; set; }
        public string Ouq_Payee_Code { get; set; }
        public string Session_Id { get; set; }
        public string Ouq_Priority { get; set; }
        public string Ouq_Card_Seq_No { get; set; }
        public string Ouq_Card_Mode { get; set; }
        public string Delivery_Status { get; set; }
        public string Ouq_Toinbox { get; set; }
        public DateTime? Ouq_Msg_Date { get; set; }
        public string Ouq_Cust_Id { get; set; }
        public int? Ouq_Seq_No { get; set; }
        public string Ouq_Cust_Name { get; set; }
        public string Ouq_Tran_Remarks { get; set; }
        public string Ouq_Dia_Receipt_No { get; set; }
        public string Ouq_Tel_Number { get; set; }
        public int? Ouq_Seq { get; set; }
        public DateTime? Ouq_Msg_Sent_Date { get; set; }
    }
}
