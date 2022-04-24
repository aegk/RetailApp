using AutoMapper;
using RetailApp.Api.ViewModels.Request;
using RetailApp.Api.ViewModels.Response;
using RetailApp.Application.Commands.Bill;
using RetailApp.Application.Models;

namespace RetailApp.Api.Mapping
{
    public class BillDiscountProfile : Profile
    {
        public BillDiscountProfile()
        {
            CreateMap<BillDiscountRequest, BillDiscountCommand>();
            CreateMap<BillDto, BillDiscountResponse>();
        }
    }
}
