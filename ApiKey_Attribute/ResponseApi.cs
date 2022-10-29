using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiKey_Attribute
{
    public class ResponseApi<T> where T : class
    {
        public ResponseApi() { }

        public ResponseApi(HttpStatusCode ok, String message = null, T data = null)
        {
            this.ok = ok;
            this.data = data;
            this.message = message;

        }
        public ResponseApi(HttpStatusCode ok, String message = null, T data = null, String developerMessage = null, int errorCode = 0)
        {
            this.ok = ok;
            this.data = data;
            this.message = message;
            this.developerMessage = developerMessage;
            this.errorCode = errorCode;
        }

        public HttpStatusCode ok { get; set; }
        public String message { get; set; }
        public T data { get; set; }
        public String developerMessage { get; set; }
        public int errorCode { get; set; }

    }
}
