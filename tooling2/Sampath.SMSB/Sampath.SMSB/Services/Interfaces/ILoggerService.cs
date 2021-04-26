using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Services.Interfaces
{
    public interface ILoggerService
    {
        void LogCDCIError(String message);

       void LogAllSMSBTxns(String message);
    }
}
