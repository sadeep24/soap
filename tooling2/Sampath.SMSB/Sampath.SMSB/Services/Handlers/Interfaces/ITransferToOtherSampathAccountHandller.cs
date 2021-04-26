using Sampath.SMSB.Services.Models;

namespace Sampath.SMSB.Services.Handlers.Interfaces
{
    public interface ITransferToOtherSampathAccountHandller
    {
        void Handle(Message message);
    }
}