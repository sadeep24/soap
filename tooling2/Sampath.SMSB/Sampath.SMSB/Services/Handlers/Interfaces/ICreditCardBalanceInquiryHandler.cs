using Sampath.SMSB.Services.Models;

namespace Sampath.SMSB.Services.Handlers.Interfaces
{
    public interface ICreditCardBalanceInquiryHandler
    {
        void Handle(Message message);
    }
}