using AutoMapper;
using Enternova.Blog.Dtos.Entities.Security.User;
using Enternova.Blog.Models.Entities.Security;

namespace Enternova.Blog.Api.Mappers
{
    public class SecurityMapper : Profile
    {
        public SecurityMapper()
        {
            CreateMap<InUser, User>();
            CreateMap<User, OutUser>();
        }
    }
}
