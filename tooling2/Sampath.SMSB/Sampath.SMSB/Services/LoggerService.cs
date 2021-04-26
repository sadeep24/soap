using log4net;
using Sampath.SMSB.Services.Interfaces;
using Sampath.SMSB.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Sampath.SMSB.Services
{
    public class LoggerService:ILoggerService
    {
        public void LogCDCIError(String message)
        {
            ILog logger = LogManager.GetLogger("Async");
            logger.Info(message);
        }
        public void LogAllSMSBTxns(String message)
        {
            ILog logger = LogManager.GetLogger("Sync");
            logger.Info(message);
        }
    }
}
