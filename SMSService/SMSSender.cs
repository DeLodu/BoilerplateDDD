using System;
using System.IO;
using System.Net;
using Domain.DependencyContracts;

namespace SMSService
{
    public class SMSSender : ISMSSender
    {
        public string ServerURL { get; set; }

        public void SentSMS()
        {
            //HttpWebRequest request = WebRequest.Create("http://www.url.com/api/Memberapi") as HttpWebRequest;
            ////optional
            //HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //Stream stream = response.GetResponseStream();
        }
    }
}
