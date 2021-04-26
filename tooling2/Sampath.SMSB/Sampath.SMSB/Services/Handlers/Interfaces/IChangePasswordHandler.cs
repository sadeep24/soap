using Sampath.SMSB.Services.Models;

namespace Sampath.SMSB.Services.Handlers.Interfaces
{
    public interface IChangePasswordHandler
    {
        void Handle(Message message);
    }
}