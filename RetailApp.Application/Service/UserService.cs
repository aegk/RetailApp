﻿using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RetailApp.Application.Models;
using RetailApp.Domain.Common;
using RetailApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace RetailApp.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _context;
        public UserService(IRepository<User> userRepository, IMapper mapper, IConfiguration configuration, IHttpContextAccessor context)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
            _context = context;
        }

        public async Task<AuthenticationUser> AuthenticateAndGenerateSecret(string email, string password, int customerType)
        {
            var user = await GetUser(email, password,customerType);
            if (user == null) return null;
            var token = GenerateJWTToken(email, password);
            user.Secret = token;
            _context.HttpContext.Items["User"] = user;
            return user;
        }

        public string GenerateJWTToken(string email, string password)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("JwtSettings").GetSection("JwtKey").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim("useremail",email),
                new Claim("password",password)
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public Task<AuthenticationUser> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthenticationUser> GetCurrentUser()
        {
            
            var user = _context.HttpContext.Items["User"] as AuthenticationUser;
            return user;
        }

        /// <summary>
        /// For Test
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="customerType"></param>
        /// <returns></returns>
        public async Task<AuthenticationUser> GetUser(string email, string password, int customerType)
        {
            var user = await _userRepository.GetUserAsync(email, password, customerType);
            return _mapper.Map<AuthenticationUser>(user);
        }

        public async Task<AuthenticationUser> GetUser(string email, string password)
        {
            var user = await _userRepository.GetUserAsync(email, password);
            return _mapper.Map<AuthenticationUser>(user);
        }
    }
}
