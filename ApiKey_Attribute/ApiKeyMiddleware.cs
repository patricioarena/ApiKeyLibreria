using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiKey_Attribute
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string APIKEYNAME = "ApiKey";
        private const string CLIENTIDNAME = "ClientId";
        private string APPLICATIONIDNAME;
        private string URLNAME;

        public ApiKeyMiddleware()
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

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(ActionExecutingContext context)
        {
            IPAddress RemoteIpAddress = context.HttpContext.Request.HttpContext.Connection.RemoteIpAddress;

            if (!context.HttpContext.Request.Headers.TryGetValue(CLIENTIDNAME, out var extractedClientId))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!context.HttpContext.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (APPLICATIONIDNAME == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            RequestDTO request = new RequestDTO()
            {
                clientId = Int32.Parse(extractedClientId),
                appId = Int32.Parse(ApplicationId),
                apiKey = new Guid(extractedApiKey),
                remoteIp = RemoteIpAddress.ToString()
            };

            ResponseApi<JObject> resp = RestClient.VerificationKey(request, UrlEndpoint);
            var isValid = resp.data.Value<bool>("isValid");

            if (!isValid.Equals(true))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await _next(context.HttpContext);
        }
    }
}
