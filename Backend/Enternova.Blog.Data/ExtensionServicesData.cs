using Enternova.Blog.Data.Context;
using Enternova.Blog.Data.Repositories.Implementations;
using Enternova.Blog.Data.Repositories.Implementations.Security;
using Enternova.Blog.Data.Repositories.Interfaces;
using Enternova.Blog.Data.Repositories.Interfaces.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Enternova.Blog.Data
{
    public static class ExtensionServicesData
    {
        public static IServiceCollection AddBlogDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EnternovaBlogContext>(options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.EnableSensitiveDataLogging();

                options.UseSqlServer(configuration.GetConnectionString("Local"), sqlOptions =>
                    sqlOptions.MigrationsAssembly("Enternova.Blog.Api"));
            });


            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
