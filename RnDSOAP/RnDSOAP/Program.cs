using RnDSOAP.Services;
using RnDSOAP.Services.Interfaces;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Xml;

namespace RnDSOAP
{
    class Program
    {

        async static Task Main(string[] args)
        {

            ISoapDemoApi soapDemoApi = new SoapDemoApi();
            //var output = await soapDemoApi.GetCityDetails("10001");
            //Console.WriteLine(output.City);
            //Console.WriteLine(output.State);
            //Console.WriteLine(output.Zip);
            Execute();
        }
        public static void Execute()
        {
            var _url = "https://www.crcind.com/csp/samples/SOAP.Demo.cls";
            var _action = "http://tempuri.org/SOAP.Demo.LookupCity";

            HttpWebRequest request = CreateWebRequest(_url, _action);
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org"">
                <soapenv:Header/>
                <soapenv:Body>
                    <tem:LookupCity>
                        <!--Optional:-->
                        <tem:zip>10011</tem:zip>
                     </tem:LookupCity>
                 </soapenv:Body>
                </soapenv:Envelope>");
            try
            {
                using (Stream stream = request.GetRequestStream())
                {
                    soapEnvelopeXml.Save(stream);
                }

                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        string soapResult = rd.ReadToEnd();
                        Console.WriteLine(soapResult);
                    }
                }
            }
            catch(Exception ex)
            {
                var t = ex.Message;
            }
           
        }
        /// <summary>
        /// Create a soap webrequest to [Url]
        /// </summary>
        /// <returns></returns>
        public static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("soapAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }
    }
}
