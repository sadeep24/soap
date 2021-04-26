using Sampath.SMSB.Services.Models;

namespace Sampath.SMSB.Services.Handlers.Interfaces
{
    public interface IReloadUsingDefaultAccountHandler
    {
        void Handle(Message message);
    }
}