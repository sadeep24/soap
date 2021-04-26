using Sampath.SMSB.Services.Models;

namespace Sampath.SMSB.Services.Handlers.Interfaces
{
    public interface ISettleCreditCardOutstandingBalanceHandler
    {
        void Handle(Message message);
    }
}