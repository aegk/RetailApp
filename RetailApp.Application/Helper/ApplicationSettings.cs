using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailApp.Application.Helper
{
    public class ApplicationSettings
    {
        public class JwtSettings
        {
            public string JwtKey { get; set; }
            public string JwtIssuer { get; set; }
        }
    }
}
