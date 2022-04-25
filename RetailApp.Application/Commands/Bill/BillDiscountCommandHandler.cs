using MediatR;
using RetailApp.Application.Enums;
using RetailApp.Application.Models;
using RetailApp.Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailApp.Application.Commands.Bill
{
    public class BillDiscountCommandHandler : IRequestHandler<BillDiscountCommand, BillDto>
    {
        private readonly IBillDiscountService _discountService;
        private readonly IUserService _userService;

        public BillDiscountCommandHandler(IBillDiscountService discountService, IUserService userService)
        {
            _discountService = discountService;
            _userService = userService;
        }
        public async Task<BillDto> Handle(BillDiscountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetCurrentUser();
            var bill = new BillDto();

            if (user.CustomerType == (int)CustomerType.Employee)
                bill = await _discountService.GetDiscountsForEmployee(request.BillAmount);
            else if (user.CustomerType == (int)CustomerType.Affiliate)
                bill = await _discountService.GetDiscountsForAffiliate(request.BillAmount);
            else if (user.CustomerType == (int)CustomerType.OldCustomer)
                bill = await _discountService.GetDiscountsForOldCustomer(request.BillAmount);
            else if (user.CustomerType == (int)CustomerType.None)
                bill = await _discountService.GetDiscountsForNewCustomer(request.BillAmount);

            return bill;
        }
    }
}
