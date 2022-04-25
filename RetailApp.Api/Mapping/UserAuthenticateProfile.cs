using AutoMapper;
using RetailApp.Api.ViewModels.Request;
using RetailApp.Application.Commands.AuthenticateUserCommand;

namespace RetailApp.Api.Mapping
{
    public class UserAuthenticateProfile : Profile
    {

        public UserAuthenticateProfile()
        {
            CreateMap<UserAuthenticateRequest, AuthenticateUserCommand>();
        }
    }
}
