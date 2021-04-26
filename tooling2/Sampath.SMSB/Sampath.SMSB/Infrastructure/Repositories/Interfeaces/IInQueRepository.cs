using Sampath.SMSB.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sampath.SMSB.Infrastructure.Repositories.Interfeaces
{
    public interface IInQueRepository
    {
        Task<IEnumerable<InQue>> GetAllProducts();
        Task UpbateInqReq(string teliponde, string encmessage);
    }
}
