using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AcumaticaHackathon
{
    public class WebRequest
    {
        //move to setup
        //public const String AcumaticaURL = "http://localhost/hackathon/(W(1))/Main.aspx?ScreenId=";
        //public const String SlackURL = "https://hooks.slack.com/services/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";

        public static void postRequest(string SlackURL, SimpleMessage message)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var json = createJSON(message);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var result = client.PostAsync(SlackURL, content).Result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void postRequest(string SlackURL, DetailMessage message)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var json = createJSON(message);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var result = client.PostAsync(SlackURL, content).Result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string createJSON(object obj)
        {
            try
            {
                string json = JsonConvert.SerializeObject(obj);
                return json;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SlackMessage createTestSlackMessage()
        {
            SlackMessage message = new SlackMessage()
            {
                Channel = "#random",
                Pretext = "Hello from Acumatica.....",
                Title = "Message Title",
                Username = "John",
                //Text = "Detailed Message goes Here...",
                Fallback = "Fallback",
                Color = "danger", //"#36a64f"
                IsSimple = true,
                TextDetail = "Some Text Detail",
                ScreenURL = "SO301000&OrderType=SO&OrderNbr=000586",
                ScreenURLDescr = "Sales Order 000586",
                FieldShort = "false",
                FieldTitle = "Field Title",
                FieldValue = "Field Value"
            };
            return message;
        }

    }

   

}
