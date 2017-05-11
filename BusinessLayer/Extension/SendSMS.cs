using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Extension
{
    public class SendSMS
    {


        public String Send(string mobile, string message)
        {
            String result = GetPageContent(@"http://smslogin.mobi/spanelv2/api.php?username=jahhyd&password=jahhyd&to=" + mobile + "&from=JAHHYD&message=" + message + "");
            return result;
        }
        private static string GetPageContent(string FullUri)
        {
            HttpWebRequest Request;
            StreamReader ResponseReader;
            Request = ((HttpWebRequest)(WebRequest.Create(FullUri)));
            ResponseReader = new StreamReader(Request.GetResponse().
    GetResponseStream());
            return ResponseReader.ReadToEnd();
        }
    }
}
