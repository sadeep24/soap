using Sampath.SMSB.Services.Models;

namespace Sampath.SMSB.Services.Handlers.Interfaces
{
    public interface IMessageDecryptHandler
    {
        void Handle(Message message);
    }
}