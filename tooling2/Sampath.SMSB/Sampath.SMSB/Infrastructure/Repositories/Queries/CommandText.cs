using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Infrastructure.Repositories.Queries
{
    class CommandText:ICommandText
    {
        public string GetSMS => "Select * from SMB_INQUE";
        public string GetProducts => "Select * from Product";
      
        public string InsertOutQue => "Insert into SMB_OUTQUE_MERGED (Ouq_Outrec, Ouq_Processed, Ouq_Payee_Code, Session_Id, Ouq_Priority, Ouq_Card_Seq_No, Ouq_Card_Mode, Delivery_Status, Ouq_Toinbox, Ouq_Msg_Date, Ouq_Cust_Id, Ouq_Seq_No, Ouq_Cust_Name, Ouq_Tran_Remarks, Ouq_Dia_Receipt_No, Ouq_Tel_Number, Ouq_Seq, Ouq_Msg_Sent_Date) values (:Ouq_Outrec, :Ouq_Processed, :Ouq_Payee_Code, :Session_Id, :Ouq_Priority, :Ouq_Card_Seq_No, :Ouq_Card_Mode, :Delivery_Status, :Ouq_Toinbox, :Ouq_Msg_Date, :Ouq_Cust_Id, :Ouq_Seq_No, :Ouq_Cust_Name, :Ouq_Tran_Remarks, :Ouq_Dia_Receipt_No, :Ouq_Tel_Number, :Ouq_Seq, :Ouq_Msg_Sent_Date)";
        public string UpdateProduct => "Update [Dapper].[dbo].[Product] set Name = :Name, Cost = :Cost, CreatedDate = GETDATE() where Id =:Id";
        public string RemoveProduct => "Delete from [Dapper].[dbo].[Product] where Id= :Id";
        public string GetProductByIdSp => "GetProductId";

        //Telebanking
        public string GetTeleBankingDetails => "SELECT * FROM SMSMTN where smsPhoneno =:SmsPhoneno";
        public string GetRetryCount => "SELECT Sms_Retry_Count from SMSMTN where SMSTELBANKNO = :TeleBankNo";
        public string SetEncRec=> "UPDATE SMB_INQUE SET INQ_INREC=:Enc Where INQ_TEL_NUMBER = :Tele";
        public string SuspendTeleBanking => "UPDATE SMB_INQUE SET INQ_INREC=:Enc Where INQ_TEL_NUMBER = :Tele";

        //Customer
        public string GetCustomerDetails => "SELECT * FROM Cust_Details where Cust_Telbank_no=:TeleBankNo";

        //Transaction
        public string InsertTransaction => "Insert into SMB_TRANSACTIONS (Tbno, Card_Seq_No, Txn_Id, Mobile_No, Date_Time, Incoming_Msg, Reply_Msg, Tran_Type, Acc_Acc_No, Acc_Acc_Code, Acc_Bal, Debit_Acc_Code, Debit_Acc_No, Credit_Acc_Code, Credit_Acc_No, Tfr_Amount, Tfr_Fund_Seq_No, Tfr_To_Bank, Tfr_To_Branch, Reference, Ref_No_Auth_Code, Tfr_Name, Credit_Card_Code, Credit_Card_No, Merchant_Id, Invoice_No, Phone_No, Salesmen_Mobile_No, Revenue_Licence_No, Vehicle_Reg_No, Chassis_No, Green_Test, Insurence_Comp, Cheque_No, Cheque_Status, Remark1, Remark2, Seq_No, Conn_Code, Date_Time_Db, Status) values (:Tbno, :Card_Seq_No, :Txn_Id, :Mobile_No, :Date_Time, :Incoming_Msg, :Reply_Msg, :Tran_Type, :Acc_Acc_No, :Acc_Acc_Code, :Acc_Bal, :Debit_Acc_Code, :Debit_Acc_No, :Credit_Acc_Code, :Credit_Acc_No, :Tfr_Amount, :Tfr_Fund_Seq_No, :Tfr_To_Bank, :Tfr_To_Branch, :Reference, :Ref_No_Auth_Code, :Tfr_Name, :Credit_Card_Code, :Credit_Card_No, :Merchant_Id, :Invoice_No, :Phone_No, :Salesmen_Mobile_No, :Revenue_Licence_No, :Vehicle_Reg_No, :Chassis_No, :Green_Test, :Insurence_Comp, :Cheque_No, :Cheque_Status, :Remark1, :Remark2, :Seq_No, :Conn_Code, :Date_Time_Db, :Status)";
    }
}
