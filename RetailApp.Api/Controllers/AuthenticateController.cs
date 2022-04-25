using MediatR;
using Microsoft.AspNetCore.Mvc;
using RetailApp.Application.Commands.AuthenticateUserCommand;

namespace RetailApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Authenticate with email and password
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateUserCommand request)
        {
            var authUser = await _mediator.Send(request);
            return Ok(authUser);
        }
    }
}
