using Enternova.Blog.Domain.Services.Interfaces;
using Enternova.Blog.Dtos.Base;
using Enternova.Blog.Models.Base;
using Enternova.Blog.Util.QueryParams.Base;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Enternova.Blog.Api.Controllers.V1.Base
{
    public class EnternovaBaseGetController<OutDto, Entity, QueryParams, IdType> : ControllerBase
        where Entity : BaseModel<IdType>
        where QueryParams : QueryParams<Entity>
    {
        private readonly IGetService<OutDto, Entity, QueryParams, IdType> _service;

        public EnternovaBaseGetController(
            IGetService<OutDto, Entity, QueryParams, IdType> service)
        {
            this._service = service;
        }


        /// <summary>
        /// Metodo para obtener varias entidades
        /// </summary>
        [HttpGet]
        public virtual async Task<ActionResult<StatusData<IEnumerable<OutDto>>>> GetAsync([FromQuery] QueryParams queryParams)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(HttpContext.Request.Headers["x-culture"]);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(HttpContext.Request.Headers["x-culture"]);


            var data = await _service.GetAsync(queryParams);
            return data;
        }

        /// <summary>
        /// Metodo para traer una unica entidad
        /// </summary>
        [HttpGet("{Id}")]
        public virtual async Task<ActionResult<StatusData<OutDto>>> GetFirstAsync([FromRoute] IdType Id)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(HttpContext.Request.Headers["x-culture"]);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(HttpContext.Request.Headers["x-culture"]);

            var data = await _service.GetFirstAsync(Id);
            return data;
        }
    }
}
