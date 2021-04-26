using Sampath.SMSB.Services.Models;

namespace Sampath.SMSB.Services.Handlers.Interfaces
{
    public interface IReloadUsingSpecificAccount
    {
        void Handle(Message message);
    }
}