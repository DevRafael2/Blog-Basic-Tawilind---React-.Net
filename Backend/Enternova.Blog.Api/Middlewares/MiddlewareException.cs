using Enternova.Blog.Data.Repositories.Interfaces;
using Enternova.Blog.Domain.Services.Implementations;
using Enternova.Blog.Dtos.Base;
using Enternova.Blog.Lang.Services;
using Enternova.Blog.Models.Entities.Logs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Enternova.Blog.Api.Middlewares
{
    public class MiddlewareException
    {
        private readonly RequestDelegate _next;
        private readonly IRepository<ErrorLog, Guid> _logErrorRepository;
        private readonly IStringLocalizer<BaseService> stringLocalizer;

        public MiddlewareException(RequestDelegate next, IServiceScopeFactory _serviceScopeFactory)
        {
            _next = next;
            var scope = _serviceScopeFactory.CreateScope();

            var serviceProvider = scope.ServiceProvider;
            this._logErrorRepository = serviceProvider.GetRequiredService<IRepository<ErrorLog, Guid>>();
            this.stringLocalizer = serviceProvider.GetRequiredService<IStringLocalizer<BaseService>>();
        }

        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                var status = await _logErrorRepository.CreateAsync(new ErrorLog
                {
                    Message = ex.Message,
                    InnerException = ex.InnerException?.ToString(),
                    Source = ex.Source,
                    TargetSite = ex.TargetSite?.ToString(),
                    Trace = ex.StackTrace
                });
                await _logErrorRepository.SaveChangesAsync();

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                var response = JsonConvert.SerializeObject(new Status
                {
                    IsComplete = false,
                    Message = $"{this.stringLocalizer["error_application"]} {status.Data.Id}",
                });

                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(response);
            }
        }
    }

    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseEnternovaExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareException>();
        }
    }
}
