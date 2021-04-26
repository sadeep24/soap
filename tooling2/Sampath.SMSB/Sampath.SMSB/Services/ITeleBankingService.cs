using Sampath.SMSB.Services.Models;
using System.Threading.Tasks;

namespace Sampath.SMSB.Services
{
    public interface ITeleBankingService
    {
        Task<string> GetTeleBankingNumber(Message message);
    }
}