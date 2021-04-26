using Sampath.SMSB.Infrastructure.Models;
using Sampath.SMSB.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sampath.SMSB.Infrastructure.Repositories.Interfeaces
{
    public interface ISMSMTNRepository
    {
        Task<Smsmtn> GetTeleBankingDetails(Message message);
        Task<int> GetRetryCount(string smsPhoneno);
        Task SetRetryCount(string smsPhoneno, int count);
        Task SuspendTeleBanking(string smsPhoneno);
    }
}