using Sampath.SMSB.Services.Models;

namespace Sampath.SMSB.Services.Handlers.Interfaces
{
    public interface ISLTReloadBillPaymentHandler
    {
        void Handle(Message message);
    }
}