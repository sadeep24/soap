using Sampath.SMSB.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Services
{
    public class MissedCallReloadService : IMissedCallReloadService
    {
        public void printMessage()
        {
            Console.WriteLine("MissedCallReloadService");
        }
    }
}
