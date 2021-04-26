using Sampath.SMSB.Services.Models;

namespace Sampath.SMSB.Services.Handlers.Interfaces
{
    public interface IBillPaymentHandler
    {
        void Handle(Message message);
    }
}