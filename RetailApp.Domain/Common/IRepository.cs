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
        /// <summary>
        /// for test
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="customerType"></param>
        /// <returns></returns>
       Task<User> GetUserAsync(string email, string password, int customerType);

        Task<User> GetUserAsync(string email, string password);
    }
}
