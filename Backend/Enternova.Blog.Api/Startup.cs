using Enternova.Blog.Api.HostedService;
using Enternova.Blog.Api.Middlewares;
using Enternova.Blog.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Globalization;
using System.Text;

namespace Enternova.Blog.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization();
            services.AddAutoMapper(typeof(Startup));
            services.AddBlogServices(this.Configuration);
            services.AddHostedService<RunValidateUserService>();
            services.AddAuthentication(x =>
            {
                x.DefaultScheme = "Bearer";
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateActor = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecurityKey"])),
                    ClockSkew = TimeSpan.Zero,
                };
            });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void ConfigureApplication(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            var supportedCultures = new[]
{
                new CultureInfo("en-US"),
                new CultureInfo("es-CO"),
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("es-CO"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                ApplyCurrentCultureToResponseHeaders = true
            });
            app.UseCors(c =>
            {
                c.AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod();
            });
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();
            app.UseEnternovaExceptionMiddleware();
        }

    }
}
