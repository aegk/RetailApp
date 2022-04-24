using MediatR;
using RetailApp.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailApp.Application.Commands.Bill
{
    public class BillDiscountCommand : IRequest<BillDto>
    {
        public decimal BillAmount { get; set; }
    }
}
