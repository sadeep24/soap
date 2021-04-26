using Sampath.SMSB.Services.Models;

namespace Sampath.SMSB.Services.Handlers.Interfaces
{
    public interface ITransferToOtherBankAccountHandler
    {
        void Handle(Message message);
    }
}