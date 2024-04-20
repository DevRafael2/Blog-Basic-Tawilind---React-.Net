using Enternova.Blog.Dtos.Base;

namespace Enternova.Blog.Domain.Services.Interfaces
{
    public interface ISendService<InDto, OutDto, IdType>
    {
        /// <summary>
        /// Crea una nueva entidad
        /// </summary>
        public Task<StatusData<OutDto>> CreateAsync(InDto InEntity);
        /// <summary>
        /// Actualiza una entidad
        /// </summary>
        public Task<Status> UpdateAsync(IdType Id, InDto InEntity);
        /// <summary>
        /// Elimina definitivamente una entidad
        /// </summary>
        public Task<Status> DeleteAsync(IdType Id);
    }
}
