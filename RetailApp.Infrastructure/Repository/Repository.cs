using RetailApp.Domain.Common;
using RetailApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailApp.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        /// <summary>
        /// For Test
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="customerType"></param>
        /// <returns></returns>
        public async Task<User> GetUserAsync(string email, string password, int customerType)
        {
           

            var user = new User();
            user.Email = email;
            user.Name = "Test";
            user.CustomerType = customerType;
            user.Id = 1;
            return  user;
        }

        public async Task<User> GetUserAsync(string email, string password)
        {
            //dbden user alınacak
            var user = new User();
            return user;

        }
    }
}
