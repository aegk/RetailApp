using AutoMapper;
using RetailApp.Application.Models;
using RetailApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailApp.Application.Mapping
{
    public class AuthenticationUserMapping : Profile
    {
        public AuthenticationUserMapping()
        {
            CreateMap<User, AuthenticationUser>();
        }
    }
}
