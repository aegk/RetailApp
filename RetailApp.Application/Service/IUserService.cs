using RetailApp.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailApp.Application.Service
{
    public interface IUserService
    {
        Task<AuthenticationUser> GetById(int Id);
        Task<AuthenticationUser> GetUser(string email, string password);

        Task<AuthenticationUser> AuthenticateAndGenerateSecret(string email, string password);

        public string GenerateJWTToken(string email, string password);

        Task<AuthenticationUser> GetCurrentUser();

    }
}
