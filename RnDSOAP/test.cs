using System.Xml;
using System.Net;
using System.IO;

public static void CallWebService()
{
    var _url = "http://xxxxxxxxx/Service1.asmx";
    var _action = "http://xxxxxxxx/Service1.asmx?op=HelloWorld";

    XmlDocument soapEnvelopeXml = CreateSoapEnvelope();
    HttpWebRequest webRequest = CreateWebRequest(_url, _action);
    InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

    // begin async call to web request.
    IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

    // suspend this thread until call is complete. You might want to
    // do something usefull here like update your UI.
    asyncResult.AsyncWaitHandle.WaitOne();

    // get the response from the completed web request.
    string soapResult;
    using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
    {
        using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
        {
            soapResult = rd.ReadToEnd();
        }
        Console.Write(soapResult);        
    }
}

private static HttpWebRequest CreateWebRequest(string url, string action)
{
    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
    webRequest.Headers.Add("SOAPAction", action);
    webRequest.ContentType = "text/xml;charset=\"utf-8\"";
    webRequest.Accept = "text/xml";
    webRequest.Method = "POST";
    return webRequest;
}

private static XmlDocument CreateSoapEnvelope()
{
    XmlDocument soapEnvelopeDocument = new XmlDocument();
    soapEnvelopeDocument.LoadXml(@"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/1999/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/1999/XMLSchema""><SOAP-ENV:Body><HelloWorld xmlns=""http://tempuri.org/"" SOAP-ENV:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""><int1 xsi:type=""xsd:integer"">12</int1><int2 xsi:type=""xsd:integer"">32</int2></HelloWorld></SOAP-ENV:Body></SOAP-ENV:Envelope>");
    return soapEnvelopeDocument;
}

private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
{
    using (Stream stream = webRequest.GetRequestStream())
    {
        soapEnvelopeXml.Save(stream);
    }
}
KBBWrite

Popular Answer
I got this simple solution here:

Sending SOAP request and receiving response in .NET 4.0 C# without using the WSDL or proxy classes:

class Program
    {
        /// <summary>
        /// Execute a Soap WebService call
        /// </summary>
        public static void Execute()
        {
            HttpWebRequest request = CreateWebRequest();
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                  <soap:Body>
                    <HelloWorld xmlns=""http://tempuri.org/"" />
                  </soap:Body>
                </soap:Envelope>");

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
        /// <summary>
        /// Create a soap webrequest to [Url]
        /// </summary>
        /// <returns></returns>
        public static HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://localhost:56405/WebService1.asmx?op=HelloWorld");
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        static void Main(string[] args)
        {
            Execute();
        }
    }