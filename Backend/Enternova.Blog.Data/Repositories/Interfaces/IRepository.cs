using Enternova.Blog.Dtos.Base;
using Enternova.Blog.Models.Base;
using Enternova.Blog.Util.QueryParams.Base;

namespace Enternova.Blog.Data.Repositories.Interfaces
{
    public interface IRepository<Entity, IdType>
        where Entity : BaseModel<IdType>
    {
        /// <summary>
        /// Obtiene un dato por Id
        /// </summary>
        public Task<StatusData<Entity>> GetFirstAsync(IdType Id);
        /// <summary>
        /// Obtener todos los datos seleccionados en el filtro
        /// </summary>
        public Task<StatusData<IEnumerable<Entity>>> GetAsync(QueryParams<Entity> FilterParams = null);
        /// <summary>
        /// Crea una nueva entidad
        /// </summary>
        public Task<StatusData<Entity>> CreateAsync(Entity Entity);
        /// <summary>
        /// Actualiza una entidad
        /// </summary>
        public Task<Status> UpdateAsync(IdType Id, Entity InEntity);
        /// <summary>
        /// Elimina definitivamente una entidad
        /// </summary>
        public Task<Status> DeleteAsync(IdType Id);
        /// <summary>
        /// Metodo que guarda los cambios realizados
        /// </summary>
        /// <returns></returns>
        public Task<bool> SaveChangesAsync();
    }
}
