using AutoMapper;
using Enternova.Blog.Data.Repositories.Implementations;
using Enternova.Blog.Data.Repositories.Interfaces;
using Enternova.Blog.Domain.Services.Interfaces.Security;
using Enternova.Blog.Dtos.Base;
using Enternova.Blog.Dtos.Entities.Logs;
using Enternova.Blog.Dtos.Entities.Security.User;
using Enternova.Blog.Helpers.EncryptHelper;
using Enternova.Blog.Helpers.SecurityHelper;
using Enternova.Blog.Lang.Services;
using Enternova.Blog.Lang.Services.Security;
using Enternova.Blog.Models.Entities.Logs;
using Enternova.Blog.Models.Entities.Security;
using Enternova.Blog.Util.QueryParams;
using Enternova.Blog.Util.QueryParams.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using System.Security.Claims;

namespace Enternova.Blog.Domain.Services.Implementations.Security
{
    public class UserService : Service<InUser, OutUser, User, UserQueryParams, long>, IUserService
    {
        private readonly IRepository<LoginLog, Guid> logLoginRepository;
        private readonly IConfiguration configuration;

        public UserService(
            IRepository<LoginLog, Guid> logLoginRepository,
            IConfiguration configuration,
            IRepository<User, long> repository, 
            IMapper mapper, 
            IStringLocalizer<UserResource> stringLocalizer) : base(repository, mapper, stringLocalizer)
        {
            this.logLoginRepository = logLoginRepository;
            this.configuration = configuration;
        }

        public override Task<StatusData<OutUser>> CreateAsync(InUser InEntity)
        {
            InEntity.Password = InEntity.Password.Sha256();
            return base.CreateAsync(InEntity);
        }

        public virtual async Task<StatusData<OutUserLogin>> LoginAsync(InUserLogin creds)
        {
            CustomQueryParam<User> customQueryParam = new CustomQueryParam<User>(1, 1000);
            customQueryParam.Where = (e) => e.UserName == creds.UserName && e.Password == (creds.Password.Sha256());
            var user = await _repository.GetAsync(customQueryParam);
            if (user.Data?.Any() == false)
                return new StatusData<OutUserLogin>() { IsComplete = true, Message = _stringLocalizer["failed_login"] };

            var firstUser = user.Data.FirstOrDefault();
            var fullName = $"{firstUser.FirstName} {firstUser.FirstLastName}";
            var Token = (new List<Claim>()
            {
                new Claim("UserName", firstUser.UserName),
                new Claim("UserId", firstUser.Id.ToString()),
                new Claim("FullName", fullName),
                new Claim("Ip", creds.OriginIp)
            }).GetToken(configuration["SecurityKey"]);


            await logLoginRepository.CreateAsync(
                new LoginLog { DeviceName = creds.DeviceName, OperatingSystem = creds.OperatingSystem, IpAdress = creds.OriginIp, UserId = firstUser.Id });

            await logLoginRepository.SaveChangesAsync();
            return new StatusData<OutUserLogin>
            {
                IsComplete = true,
                Message = _stringLocalizer["success_login"],
                Data = new OutUserLogin { Token = Token, Expire = DateTime.Now.AddDays(30).ToString("dd-MM-yyyy"), UserName = firstUser.UserName, FullName = fullName, UserId = firstUser.Id },
            };
        }

        public override async Task<StatusData<OutUser>> ValidateToCreate(User entity)
        {
            entity.UserName = entity.UserName.Replace(" ", "");
            CustomQueryParam<User> userQuery = new CustomQueryParam<User>(1, 1000);
            userQuery.Where = (e) => e.UserName == entity.UserName;

            var entitiesDb = await _repository.GetAsync(userQuery);
            if (entitiesDb.Data.Any(x => x.UserName == entity.UserName.Replace(" ", "")))
                return new StatusData<OutUser> { IsComplete = false, Message = _stringLocalizer["user_name_equal"] };

            return await base.ValidateToCreate(entity);
        }

        public override async Task<Status> ValidateToUpdate(long Id, User entity)
        {
            entity.UserName = entity.UserName.Replace(" ", "");
            CustomQueryParam<User> userQuery = new CustomQueryParam<User>(1, 1000);
            userQuery.Where = (e) => e.Id != Id && e.UserName == entity.UserName;

            var entitiesDb = await _repository.GetAsync(userQuery);
            if (entitiesDb.Data.Any(x => x.UserName == entity.UserName.Replace(" ", "")))
                return new StatusData<OutUser> { IsComplete = false, Message = _stringLocalizer["user_name_equal"] };

            return await base.ValidateToCreate(entity);
        }

    }
}
