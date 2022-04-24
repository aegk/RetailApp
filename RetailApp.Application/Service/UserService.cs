using AutoMapper;
using RetailApp.Application.Models;
using RetailApp.Domain.Common;
using RetailApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailApp.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository, IMapper mapper) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<AuthenticationUser> GetCurrentUser(CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.GetById(1);

            return _mapper.Map<AuthenticationUser>(user);
        }
    }
}
