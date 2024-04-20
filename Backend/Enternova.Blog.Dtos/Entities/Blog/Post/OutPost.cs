namespace Enternova.Blog.Dtos.Entities.Blog.Post
{
    public class OutPost : InPost
    {
        /// <summary>
        /// Id de la entidad
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Nombre de usuario
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Fecha de creación
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Fecha de actualización
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
