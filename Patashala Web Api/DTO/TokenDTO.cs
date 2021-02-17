using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patashala_Web_Api.DTO
{
    public class TokenDTO
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}