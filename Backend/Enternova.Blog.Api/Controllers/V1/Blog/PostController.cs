using Enternova.Blog.Api.Controllers.V1.Base;
using Enternova.Blog.Domain.Services.Interfaces;
using Enternova.Blog.Dtos.Entities.Blog.Post;
using Enternova.Blog.Models.Entities.Blog;
using Enternova.Blog.Util.Attributes;
using Enternova.Blog.Util.QueryParams.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Enternova.Blog.Api.Controllers.V1.Blog
{
    [ApiController]
    [Route("Api/Post")]
    [VersionApi("x-version", "V1")]
    [CultureRequest("x-culture")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class PostController : EnternovaBaseController<InPost, OutPost, Post, PostQueryParams, Guid>
    {
        public PostController(IService<InPost, OutPost, Post, PostQueryParams, Guid> service) : base(service)
        {

        }
    }
}
