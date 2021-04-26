using Sampath.SMSB.Services.Models;

namespace Sampath.SMSB.Services.Handlers.Interfaces
{
    public interface IMiniStatementHandler
    {
        void Handle(Message message);
    }
}