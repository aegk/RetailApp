using RetailApp.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailApp.Application.Service
{
    public interface IBillDiscountService
    {
        Task<BillDto> GetDiscountsForEmployee(decimal billAmount, CancellationToken cancellationToken=default);
        Task<BillDto> GetDiscountsForAffiliate(decimal billAmount, CancellationToken cancellationToken=default);
        Task<BillDto> GetDiscountsForOldCustomer(decimal billAmount, CancellationToken cancellationToken=default);
        Task<BillDto> GetDiscountsForNewCustomer(decimal billAmount, CancellationToken cancellationToken=default);
        decimal GetPercentageDiscounts(decimal billAmount, CancellationToken cancellationToken = default);
    }
}
