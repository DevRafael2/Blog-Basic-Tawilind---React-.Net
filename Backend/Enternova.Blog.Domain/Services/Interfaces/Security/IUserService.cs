using Enternova.Blog.Dtos.Base;
using Enternova.Blog.Dtos.Entities.Logs;
using Enternova.Blog.Dtos.Entities.Security.User;
using Enternova.Blog.Models.Entities.Security;
using Enternova.Blog.Util.QueryParams.Security;

namespace Enternova.Blog.Domain.Services.Interfaces.Security
{
    public interface IUserService : IService<InUser, OutUser, User, UserQueryParams, long>
    {
        /// <summary>
        /// Metodo para loguearse
        /// </summary>
        public Task<StatusData<OutUserLogin>> LoginAsync(InUserLogin creds);
    }
}
