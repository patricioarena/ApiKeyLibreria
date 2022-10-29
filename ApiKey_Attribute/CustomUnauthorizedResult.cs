using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiKey_Attribute
{
    public class CustomUnauthorizedResult :object
    {
        private string titleField = "Unauthorized";
        private int statusField = 401;

        public int status
        {
            get { return statusField; }
        }

        public string title
        {
            get { return titleField; }
        }

        public string message { get; set; }
    }
}
