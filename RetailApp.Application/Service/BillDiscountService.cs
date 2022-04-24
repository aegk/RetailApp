using RetailApp.Application.Enums;
using RetailApp.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailApp.Application.Service
{
    public class BillDiscountService : IBillDiscountService
    {
        public async Task<BillDto> GetDiscountsForAffiliate(decimal billAmount, CancellationToken cancellationToken = default)
        {
            BillDto result = new BillDto();

            var totalDiscount = new decimal();

            result.GrossPrice = billAmount;

            result.CustomerTypeForDiscount = CustomerType.Affiliate;
            totalDiscount = (billAmount * 90) / 100;

            var totalDiscountForEveryHundred = GetPercentageDiscounts(billAmount);
            totalDiscount = totalDiscount + totalDiscountForEveryHundred;

            result.DiscountPrice = totalDiscount;
            result.NetPrice = billAmount - totalDiscount;

            return result;
        }

        public async Task<BillDto> GetDiscountsForEmployee(decimal billAmount, CancellationToken cancellationToken = default)
        {
            BillDto result = new BillDto();
            var totalDiscount = new decimal();

            result.GrossPrice = billAmount;

            result.CustomerTypeForDiscount = CustomerType.Employee;
            totalDiscount = (billAmount * 70) / 100;

            var totalDiscountForEveryHundred = GetPercentageDiscounts(billAmount);
            totalDiscount = totalDiscount + totalDiscountForEveryHundred;

            result.DiscountPrice = totalDiscount;
            result.NetPrice = billAmount - totalDiscount;

            return result;
        }

        public async Task<BillDto> GetDiscountsForOldCustomer(decimal billAmount, CancellationToken cancellationToken = default)
        {
            BillDto result = new BillDto();

            var totalDiscount = new decimal();

            result.GrossPrice = billAmount;

            result.CustomerTypeForDiscount = CustomerType.OldCustomer;
            totalDiscount = (billAmount * 95) / 100;

            var totalDiscountForEveryHundred = GetPercentageDiscounts(billAmount);
            totalDiscount = totalDiscount + totalDiscountForEveryHundred;

            result.DiscountPrice = totalDiscount;
            result.NetPrice = billAmount - totalDiscount;

            return result;
        }

        public async Task<BillDto> GetDiscountsForNewCustomer(decimal billAmount, CancellationToken cancellationToken = default)
        {
            BillDto result = new BillDto();

            var totalDiscount = new decimal();

            result.GrossPrice = billAmount;

            var totalDiscountForEveryHundred = GetPercentageDiscounts(billAmount);
            totalDiscount = totalDiscount + totalDiscountForEveryHundred;

            result.DiscountPrice = totalDiscount;
            result.NetPrice = billAmount - totalDiscount;

            return result;
        }

        public decimal GetPercentageDiscounts(decimal billAmount, CancellationToken cancellationToken = default)
        {
            var loopCountForHundred = (billAmount - billAmount % 100) / 100;
            var totalDiscount = loopCountForHundred * 5;
            return totalDiscount;
        }
    }
}
