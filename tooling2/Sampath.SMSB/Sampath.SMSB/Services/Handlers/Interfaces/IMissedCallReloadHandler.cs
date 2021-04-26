using Sampath.SMSB.Services.Models;

namespace Sampath.SMSB.Services.Handlers.Interfaces
{
    public interface IMissedCallReloadHandler
    {
        void Handle(Message message);
    }
}