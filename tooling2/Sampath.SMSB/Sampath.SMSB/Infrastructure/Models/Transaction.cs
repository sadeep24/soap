using System;
using System.Collections.Generic;

namespace Sampath.SMSB.Infrastructure.Models
{
    public class Transaction
    {
        public string Tbno { get; set; }
        public string Card_Seq_No { get; set; }
        public string Txn_Id { get; set; }
        public string Mobile_No { get; set; }
        public DateTime? Date_Time { get; set; }
        public string Incoming_Msg { get; set; }
        public string Reply_Msg { get; set; }
        public string Tran_Type { get; set; }
        public string Acc_Acc_No { get; set; }
        public string Acc_Acc_Code { get; set; }
        public decimal? Acc_Bal { get; set; }
        public string Debit_Acc_Code { get; set; }
        public string Debit_Acc_No { get; set; }
        public string Credit_Acc_Code { get; set; }
        public string Credit_Acc_No { get; set; }
        public decimal? Tfr_Amount { get; set; }
        public string Tfr_Fund_Seq_No { get; set; }
        public string Tfr_To_Bank { get; set; }
        public string Tfr_To_Branch { get; set; }
        public string Reference { get; set; }
        public string Ref_No_Auth_Code { get; set; }
        public string Tfr_Name { get; set; }
        public string Credit_Card_Code { get; set; }
        public string Credit_Card_No { get; set; }
        public string Merchant_Id { get; set; }
        public string Invoice_No { get; set; }
        public string Phone_No { get; set; }
        public string Salesmen_Mobile_No { get; set; }
        public string Revenue_Licence_No { get; set; }
        public string Vehicle_Reg_No { get; set; }
        public string Chassis_No { get; set; }
        public string Green_Test { get; set; }
        public string Insurence_Comp { get; set; }
        public string Cheque_No { get; set; }
        public string Cheque_Status { get; set; }
        public string Remark1 { get; set; }
        public string Remark2 { get; set; }
        public decimal? Seq_No { get; set; }
        public string Conn_Code { get; set; }
        public DateTime? Date_Time_Db { get; set; }
        public string Status { get; set; }
    }
}
