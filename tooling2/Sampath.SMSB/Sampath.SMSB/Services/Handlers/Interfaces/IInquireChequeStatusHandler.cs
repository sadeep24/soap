using Sampath.SMSB.Services.Models;

namespace Sampath.SMSB.Services.Handlers.Interfaces
{
    public interface IInquireChequeStatusHandler
    {
        void Handle(Message message);
    }
}