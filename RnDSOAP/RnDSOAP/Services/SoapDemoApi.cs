using RnDSOAP.Services.Interfaces;
using SOAPService;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RnDSOAP.Services
{
    public class SoapDemoApi: ISoapDemoApi
    {
        public readonly string serviceUrl = "http://DESKTOP-00FN7Q1:8083/";
        public readonly EndpointAddress endpointAddress;
        public readonly BasicHttpBinding basicHttpBinding;

        public SoapDemoApi()
        {
            endpointAddress = new EndpointAddress(serviceUrl);

            basicHttpBinding =
                new BasicHttpBinding(endpointAddress.Uri.Scheme.ToLower() == "http" ?
                            BasicHttpSecurityMode.None : BasicHttpSecurityMode.Transport);

            //Please set the time accordingly, this is only for demo
            basicHttpBinding.OpenTimeout = TimeSpan.MaxValue;
            basicHttpBinding.CloseTimeout = TimeSpan.MaxValue;
            basicHttpBinding.ReceiveTimeout = TimeSpan.MaxValue;
            basicHttpBinding.SendTimeout = TimeSpan.MaxValue;
        }

        public async Task<SOAPDemoSoapClient> GetInstanceAsync()
        {
            return await Task.Run(() => new SOAPDemoSoapClient(basicHttpBinding, endpointAddress));
        }

        public async Task<Address> GetCityDetails(string zipCode)
        {
            var client = await GetInstanceAsync();
            var response = await client.LookupCityAsync(zipCode);
            return response;
        }
    }
}
