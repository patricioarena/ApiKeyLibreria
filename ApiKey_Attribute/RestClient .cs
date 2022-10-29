using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiKey_Attribute
{
    public static class RestClient
    {
        public static ResponseApi<JObject> VerificationKey(RequestDTO request, string endpoint)
        {
            ResponseApi<JObject> result = null;
            var responseString = "";

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = endpoint;
                    webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string data = JsonConvert.SerializeObject(request);
                    responseString = webClient.UploadString(endpoint, data);
                    result = JsonConvert.DeserializeObject<ResponseApi<JObject>>(responseString);
                    return result;
                }
            }
            catch (WebException we)
            {
                int statusCode = (int)HttpStatusCode.InternalServerError;
                if (we.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = we.Response as HttpWebResponse;
                    if (response != null)
                    {
                        statusCode = (int)response.StatusCode;
                        using (StreamReader r = new StreamReader(((HttpWebResponse)we.Response).GetResponseStream()))
                        {
                            responseString = r.ReadToEnd();
                        }
                    }
                }

                JObject o = new JObject();
                o.Add("isValid", false);
                result = JsonConvert.DeserializeObject<ResponseApi<JObject>>(responseString);
                result.data = o;
                return result;
            }
        }

    }
}
