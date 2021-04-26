using Sampath.SMSB.Services.Models;

namespace Sampath.SMSB.Services.Handlers.Interfaces
{
    public interface IBalanceInqueryHandler
    {
        void Handle(Message message);
    }
}