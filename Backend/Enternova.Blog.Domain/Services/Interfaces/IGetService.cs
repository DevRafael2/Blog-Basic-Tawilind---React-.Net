using Enternova.Blog.Dtos.Base;
using Enternova.Blog.Util.QueryParams.Base;

namespace Enternova.Blog.Domain.Services.Interfaces
{
    public interface IGetService<OutDto, Entity, QueryParam, IdType> where QueryParam : QueryParams<Entity>
    {
        /// <summary>
        /// Obtiene un dato por Id
        /// </summary>
        public Task<StatusData<OutDto>> GetFirstAsync(IdType Id);
        /// <summary>
        /// Obtener todos los datos seleccionados en el filtro
        /// </summary>>
        public Task<StatusData<IEnumerable<OutDto>>> GetAsync(QueryParam FilterParams = null);
    }
}
