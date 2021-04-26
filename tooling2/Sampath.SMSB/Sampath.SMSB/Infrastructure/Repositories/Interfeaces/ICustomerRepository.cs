using Sampath.SMSB.Infrastructure.Models;
using System.Threading.Tasks;

namespace Sampath.SMSB.Infrastructure.Repositories.Interfeaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerDetails(string teleBankNo);
    }
}