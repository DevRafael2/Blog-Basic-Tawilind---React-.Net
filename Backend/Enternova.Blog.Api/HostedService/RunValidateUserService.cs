
using Enternova.Blog.Data.Repositories.Interfaces.Security;
using Enternova.Blog.Helpers.EncryptHelper;
using Enternova.Blog.Models.Entities.Security;
using Enternova.Blog.Util.QueryParams;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Enternova.Blog.Api.HostedService
{
    public class RunValidateUserService : IHostedService
    {
        private readonly IUserRepository UserRepository;
        public RunValidateUserService(IServiceScopeFactory serviceScopeFactory)
        {
            var scope = serviceScopeFactory.CreateScope().ServiceProvider;
            this.UserRepository = scope.GetRequiredService<IUserRepository>();
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var UserQueryParams = new CustomQueryParam<User>(1,1000);
            UserQueryParams.Where = (d) => d.UserName == "UserAdmin";
            UserQueryParams.Select = (d) => new User { UserName = d.UserName };

            var result = await UserRepository.GetAsync(UserQueryParams);
            if(result.Data?.Any() != true)
            {
                await UserRepository.CreateAsync(new User() { FirstName = "Prueba", FirstLastName = "Admin", Password = "Admin123".Sha256(), UserName = "UserAdmin"});
                await UserRepository.SaveChangesAsync();
            }
            
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
