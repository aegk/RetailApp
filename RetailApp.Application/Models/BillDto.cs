using RetailApp.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailApp.Application.Models
{
    public class BillDto
    {
        public decimal GrossPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public CustomerType CustomerTypeForDiscount { get; set; }
        public decimal NetPrice { get; set; }
    }
}
