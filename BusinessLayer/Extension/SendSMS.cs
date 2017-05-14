using FirebaseNet.Messaging;
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


        public void SendPushNotification(List<string> deviceList, string messge,string type)
        {
            deviceList.ForEach(x =>
            {
                FCMClient client = new FCMClient("AAAAylgXv6E:APA91bHxCtlKnoU7NBp9P989-zIh8KS6oy6dG2ESyReH6DyaawXz9zfyogpiO6STy7-8ajMzlvpi1jAQ0VqOkKjSf8DtOk5vNbklD9q-F1V3rmAnR_oH-zYamaeTludLGqItoSjykVDe");
                var message = new Message()
                {
                    To = x,
                    //Notification = new AndroidNotification()
                    //{
                    //    Title = toactive.Name + " test is avaliable.",
                    //}
                    Data = new Dictionary<string, string>
                       {
                           //{ "Nick", "Mario" },
                           { "Body", messge },
                            { "Type", type }
                       }
                };
                var result = client.SendMessageAsync(message);
            });
        }
    }
}
