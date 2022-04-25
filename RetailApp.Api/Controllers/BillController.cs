using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailApp.Api.MiddleWare;
using RetailApp.Api.ViewModels.Request;
using RetailApp.Api.ViewModels.Response;
using RetailApp.Application.Commands.Bill;
using AuthorizeAttribute = RetailApp.Api.MiddleWare.AuthorizeAttribute;

namespace RetailApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BillController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(BillDiscountResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> BillDiscount([FromQuery] BillDiscountRequest request)
        {
            var query = _mapper.Map<BillDiscountCommand>(request);
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
