using Sampath.SMSB.Services.Models;

namespace Sampath.SMSB.Services.Handlers.Interfaces
{
    public interface IStopChequeHandler
    {
        void Handle(Message message);
    }
}