using RetailApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailApp.Domain.Entities
{
    public class User : Entity
    {
       
        public string Name { get; set; }
        public int CustomerType { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
