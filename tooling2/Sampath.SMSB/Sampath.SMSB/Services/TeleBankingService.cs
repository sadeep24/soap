using Sampath.Common;
using Sampath.SMSB.Infrastructure.Repositories.Interfeaces;
using Sampath.SMSB.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Sampath.SMSB.Services
{
    public class TeleBankingService : ITeleBankingService
    {
        private readonly ISMSMTNRepository _SMSMTNRepository;
        private readonly ISMSService _smsService;
        private readonly ICustomerRepository _customerRepository;
        public async Task<String> GetTeleBankingNumber(Message message)
        {
            
            var telebanking = await _SMSMTNRepository.GetTeleBankingDetails(message);

            if (telebanking == null)
            {
                message.Reply = "SMS banking registration required. Please inq : 011 -230 3050";
               
            }else if (telebanking.Smsstatus == "S")
            {
                message.Reply = "Your Phone is Suspended from SMS Banking Service. You may inquire from your Branch";
            }
            else if(telebanking.Smsstatus == "I")
            {
                message.Reply = "SMS Banking Service is Inactive on your phone. Please contact the nearest branch or call 011-2303050";
            }

            var customerDetails =await  _customerRepository.GetCustomerDetails(message.TxnId.Substring(4));
            if (customerDetails == null)
            {
                message.Reply = "Error processing your request. Please try again else contact your branch..";
            }
            else if (customerDetails.Cust_Status != "N")
            {
                message.Reply = "Your SMS Banking service is suspended. You may inquire from your branch";
            }

            if (message.Reply != null)
            {
                await _smsService.SendSMS(message);
                return null;
            }
            return telebanking.Smstelbankno;

        }
        public async Task<bool> ValidatePinNumber(Message message, string telebankNo)
        {
            var count = await _SMSMTNRepository.GetRetryCount(telebankNo);
            int pinNo;
            if(Int32.TryParse(message.Reply.Substring(0,4), out pinNo))
            {
                message.Reply = "Error processing your request. Please try again else contact your branch..";

            }

            var customer = await _customerRepository.GetCustomerDetails(telebankNo);
            if (customer == null)
            {
                message.Reply = "Error processing your request. Please try again else contact your branch..";

            }
            if(customer.Cust_Tpin_No!= PINEncriptor.Encrypt(pinNo))
            {
               
                switch (count)
                {
                    case 0:
                        message.Reply = "Incorrect PIN." + Strings.Chr(10) +"Please try again." + Strings.Chr(10) +"You are left with 2 more attempts.";
                        await _SMSMTNRepository.SetRetryCount(telebankNo, 1);
                        break;
                    case 1:
                        message.Reply = "Incorrect PIN." + Strings.Chr(10) + "Please try again." + Strings.Chr(10) + "You are left with 1 more attempt.";
                        await _SMSMTNRepository.SetRetryCount(telebankNo, 2);
                        break;
                    case 2:
                        message.Reply = "Your Phone is Suspended from SMS Banking Service. You may inquire from your Branch";
                        await _SMSMTNRepository.SuspendTeleBanking(telebankNo);
                        break;
                }
            }
            else
            {
                if (count==2 || count==1)
                {
                    await _SMSMTNRepository.SetRetryCount(telebankNo, 0);
                }
            }
            if (message.Reply != null)
            {
                await _smsService.SendSMS(message);
                return false;
            }
            return true;
        }

    }
}
