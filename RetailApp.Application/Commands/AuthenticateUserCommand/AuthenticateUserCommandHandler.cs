using MediatR;
using RetailApp.Application.Models;
using RetailApp.Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailApp.Application.Commands.AuthenticateUserCommand
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, AuthenticationUser>
    {
        IUserService _userService;

        public AuthenticateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<AuthenticationUser> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var authenticatedUser = await _userService.AuthenticateAndGenerateSecret(request.Email, request.Password);
            if (authenticatedUser == null)
                throw new Exception(message: "User Not Found");
            return authenticatedUser;
        }
    }
}
