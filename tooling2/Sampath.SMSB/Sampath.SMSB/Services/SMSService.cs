using Sampath.SMSB.Infrastructure.Models;
using Sampath.SMSB.Infrastructure.Repositories.Interfeaces;
using Sampath.SMSB.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sampath.SMSB.Services
{
    public class SMSService : ISMSService
    {
        public readonly IOutQueRepository _outQueRepository;
        public async Task SendSMS(Message message)
        {
            var smsOut = new OutQue();
            await _outQueRepository.InsertOutQue(smsOut);
        }
    }
}
