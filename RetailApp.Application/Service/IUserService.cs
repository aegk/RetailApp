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
        Task<AuthenticationUser> GetCurrentUser(CancellationToken cancellationToken = default);
    }
}
