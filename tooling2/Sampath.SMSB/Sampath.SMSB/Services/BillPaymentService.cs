using Sampath.SMSB.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Services
{
    public class BillPaymentService : IBillPaymentService
    {
        public void printMessage()
        {
            Console.WriteLine("BillPaymentService");
        }
    }
}
