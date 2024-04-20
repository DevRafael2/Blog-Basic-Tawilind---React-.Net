using Enternova.Blog.Domain.Services.Implementations;
using Enternova.Blog.Domain.Services.Interfaces;
using Enternova.Blog.Dtos.Base;
using Enternova.Blog.Models.Base;
using Enternova.Blog.Util.QueryParams.Base;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Enternova.Blog.Api.Controllers.V1.Base
{
    public class EnternovaBaseController<InDto, OutDto, Entity, QueryParams, IdType> : EnternovaBaseGetController<OutDto, Entity, QueryParams, IdType>
        where Entity : BaseModel<IdType>
        where QueryParams : QueryParams<Entity>
    {
        protected readonly IService<InDto, OutDto, Entity, QueryParams, IdType> service;

        public EnternovaBaseController(IService<InDto, OutDto, Entity, QueryParams, IdType> service) : base(service)
        {
            this.service = service;
        }

        /// <summary>
        /// Metodo para crear objetos
        /// </summary>
        [HttpPost]
        public virtual async Task<ActionResult<StatusData<OutDto>>> CreateAsync([FromBody] InDto InEntity)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(HttpContext.Request.Headers["x-culture"]);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(HttpContext.Request.Headers["x-culture"]);

            var data = await service.CreateAsync(InEntity);
            return data;
        }

        /// <summary>
        /// Metodo para actualizar objetos
        /// </summary>
        [HttpPut("{Id}")]
        public virtual async Task<ActionResult<Status>> UpdateAsync([FromRoute] IdType Id, [FromBody] InDto InEntity)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(HttpContext.Request.Headers["x-culture"]);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(HttpContext.Request.Headers["x-culture"]);

            var data = await service.UpdateAsync(Id, InEntity);
            return data;
        }

        /// <summary>
        /// Metodo para eliminar información
        /// </summary>
        [HttpDelete("{Id}")]
        public virtual async Task<ActionResult<Status>> DeleteAsync([FromRoute] IdType Id)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(HttpContext.Request.Headers["x-culture"]);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(HttpContext.Request.Headers["x-culture"]);

            var data = await service.DeleteAsync(Id);
            return data;
        }
    }
}
