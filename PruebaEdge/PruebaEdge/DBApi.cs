using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;
using System.Web;
using System.Linq;
using System.IO;
using System.Net.Http;
using System.Net;

namespace PruebaEdge
{
    public class DBApi
    {
        public dynamic Post(string url, string json, string authorization =null)
        {
            
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "application/json");
                request.AddParameter("application/json", json, ParameterType.RequestBody);
                if(authorization!=null)
                {
                    request.AddHeader("Authorization", authorization);
                }
                IRestResponse response = client.Execute(request);
                dynamic datos = JsonConvert.DeserializeObject(response.Content);
                return datos;

           
        }

        public dynamic Get(string url)
        {
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
            Stream myStream = myHttpWebResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myStream);
            String Datos = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());
            dynamic data = JsonConvert.DeserializeObject(Datos);
            return data;
        }
    }
}
