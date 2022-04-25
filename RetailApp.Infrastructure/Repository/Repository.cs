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
        public async Task<User> GetUserAsync(string email, string password)
        {
            //dbden user alınacak

            var user = new User();
            user.Email = "";
            user.Name = "";
            user.CustomerType = 1;
            user.Id = 1;
            return  user;
        }
    }
}
