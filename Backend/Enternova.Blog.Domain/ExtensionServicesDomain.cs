using Enternova.Blog.Domain.Services.Implementations;
using Enternova.Blog.Domain.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Enternova.Blog.Data;
using Enternova.Blog.Domain.Services.Interfaces.Security;
using Enternova.Blog.Domain.Services.Implementations.Security;

namespace Enternova.Blog.Domain
{
    public static class ExtensionServicesDomain
    {
        public static IServiceCollection AddBlogServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddBlogDataServices(configuration);

            services.AddScoped(typeof(IService<,,,,>), typeof(Service<,,,,>));
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
