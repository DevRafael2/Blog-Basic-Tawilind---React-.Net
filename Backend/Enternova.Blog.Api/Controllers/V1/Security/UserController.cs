using Enternova.Blog.Api.Controllers.V1.Base;
using Enternova.Blog.Domain.Services.Interfaces.Security;
using Enternova.Blog.Dtos.Base;
using Enternova.Blog.Dtos.Entities.Logs;
using Enternova.Blog.Dtos.Entities.Security.User;
using Enternova.Blog.Models.Entities.Security;
using Enternova.Blog.Util.QueryParams.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Threading.Tasks;
using System.Threading;
using Enternova.Blog.Util.Attributes;

namespace Enternova.Blog.Api.Controllers.V1.Security
{
    [ApiController]
    [Route("Api/User")]
    [VersionApi("x-version", "V1")]
    [CultureRequest("x-culture")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class UserController : EnternovaBaseController<InUser, OutUser, User, UserQueryParams, long>
    {
        public UserController(IUserService service) : base(service)
        {

        }


        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<StatusData<OutUserLogin>>> Login(InUserLogin creds)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(HttpContext.Request.Headers["x-culture"]);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(HttpContext.Request.Headers["x-culture"]);
            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            if (HttpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                ipAddress = HttpContext.Request.Headers["X-Forwarded-For"];
            }
            creds.OriginIp = ipAddress;
            return await (service as IUserService).LoginAsync(creds);
        }

        [HttpPost]
        [AllowAnonymous]
        public override async Task<ActionResult<StatusData<OutUser>>> CreateAsync([FromBody] InUser InEntity)
        {
            return await base.CreateAsync(InEntity);
        }
    }
}
