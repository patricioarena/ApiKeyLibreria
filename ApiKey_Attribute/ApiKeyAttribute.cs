using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ApiKey_Attribute
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string APIKEYNAME = "ApiKey";
        private const string CLIENTIDNAME = "ClientId";
        private string APPLICATIONIDNAME;
        private string URLNAME;

        public ApiKeyAttribute()
        {
            this.APPLICATIONIDNAME = null;
            this.UrlEndpoint = null;
        }

        public virtual string ApplicationId
        {
            get { return APPLICATIONIDNAME; }
            set { APPLICATIONIDNAME = value; }
        }

        public virtual string UrlEndpoint
        {
            get { return URLNAME; }
            set { URLNAME = value; }
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            IPAddress RemoteIpAddress = context.HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            CustomUnauthorizedResult unauthorized = new CustomUnauthorizedResult();

            if (!context.HttpContext.Request.Headers.TryGetValue(CLIENTIDNAME, out var extractedClientId))
            {
                unauthorized.message = "clientId was not found in the headers";
                context.Result = new UnauthorizedObjectResult(unauthorized);
                return;
            }

            if (!context.HttpContext.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                unauthorized.message = "apikey was not found in the headers";
                context.Result = new UnauthorizedObjectResult(unauthorized);
                return;
            }

            if (APPLICATIONIDNAME == null)
            {
                unauthorized.message = "applicationId was not found in the headers";
                context.Result = new UnauthorizedObjectResult(unauthorized);
                return;
            }

            RequestDTO request = new RequestDTO() {
                clientId = Int32.Parse(extractedClientId),
                appId = Int32.Parse(ApplicationId),
                apiKey = new Guid(extractedApiKey),
                remoteIp = RemoteIpAddress.ToString()
            };


            ResponseApi<JObject> resp = RestClient.VerificationKey(request, UrlEndpoint);
            var isValid = resp.data.Value<bool>("isValid");

            if (!isValid.Equals(true))
            {
                unauthorized.message = resp.developerMessage;
                context.Result = new UnauthorizedObjectResult(unauthorized);
                return;
            }

            await next();
        }
    }
}
