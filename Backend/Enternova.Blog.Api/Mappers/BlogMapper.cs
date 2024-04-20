using AutoMapper;
using Enternova.Blog.Dtos.Entities.Blog.Post;
using Enternova.Blog.Models.Entities.Blog;

namespace Enternova.Blog.Api.Mappers
{
    public class BlogMapper : Profile
    {
        public BlogMapper()
        {
            CreateMap<InPost, Post>();
            CreateMap<Post, OutPost>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id.ToString()))
                .ForPath(x => x.UserName, opt => opt.MapFrom(x => x.User.UserName));

        }
    }
}
