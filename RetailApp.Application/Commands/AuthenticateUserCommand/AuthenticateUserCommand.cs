using MediatR;
using RetailApp.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailApp.Application.Commands.AuthenticateUserCommand
{
    public class AuthenticateUserCommand : IRequest<AuthenticationUser>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        /// <summary>
        /// For Test
        /// </summary>
        public int CustomerType { get; set; }
    }
}
