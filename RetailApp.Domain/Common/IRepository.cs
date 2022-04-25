using RetailApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RetailApp.Domain.Common
{
    public interface IRepository<T> where T : Entity
    {
       Task<User> GetUserAsync(string email, string password);
    }
}
