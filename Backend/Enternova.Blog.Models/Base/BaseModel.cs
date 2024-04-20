namespace Enternova.Blog.Models.Base
{
    public class BaseModel<IdType>
    {
        /// <summary>
        /// Id de la entidad
        /// </summary>
        public IdType Id { get; set; }
        /// <summary>
        /// Fecha de creación
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        /// <summary>
        /// Fecha de actualización
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
