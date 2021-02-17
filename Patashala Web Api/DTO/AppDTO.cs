using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patashala_Web_Api.DTO
{
    public class AppDTO
    {
        public string Name { get; set; }
        public DateTime TokenExpiration { get; set; }
    }
}