using SOAPService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RnDSOAP.Services.Interfaces
{
    public interface ISoapDemoApi
    {
        Task<SOAPDemoSoapClient> GetInstanceAsync();
        Task<Address> GetCityDetails(string zipCode);
    }
}
