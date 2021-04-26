using Sampath.SMSB.Services.Models;
using System.Threading.Tasks;

namespace Sampath.SMSB.Services
{
    public interface ISMSService
    {
        Task SendSMS(Message message);
    }
}