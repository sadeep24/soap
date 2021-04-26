using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Infrastructure.Repositories.Queries
{
    public interface ICommandText
    {
        string GetSMS { get; }
        string GetProducts { get; }
       
        string InsertOutQue { get; }

        //OutQue
        string UpdateProduct { get; }
        string RemoveProduct { get; }
        string GetProductByIdSp { get; }

        //TeleBanking
        string GetTeleBankingDetails { get; }
        string GetRetryCount { get; }
        string SetEncRec { get; }
        string SuspendTeleBanking { get; }

        //Customer
        string GetCustomerDetails { get; }

        //Transaction
        string InsertTransaction { get; }
    }
}
