using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiKey_Attribute
{
    public class RequestDTO : Object
    {
        public int appId { get; set; }
        public int clientId { get; set; }
        public Guid apiKey { get; set; }
        public string remoteIp { get; set; }
    }
}
