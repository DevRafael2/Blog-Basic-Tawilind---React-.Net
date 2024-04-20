using Enternova.Blog.Models.Base;
using Enternova.Blog.Models.Entities.Blog;
using Enternova.Blog.Models.Entities.Logs;
using System.ComponentModel.DataAnnotations;

namespace Enternova.Blog.Models.Entities.Security
{
    public class User : BaseModel<long>
    {
        /// <summary>
        /// Nombre de usuario
        /// </summary>
        [MaxLength(12)]
        public string UserName { get; set; }
        /// <summary>
        /// Primer nombre
        /// </summary>
        [MaxLength(12)]
        public string FirstName { get; set; }
        /// <summary>
        /// Primer apellido
        /// </summary>
        [MaxLength(12)]
        public string FirstLastName { get; set; }
        /// <summary>
        /// Contraseña del usuario en Sha256
        /// </summary>
        [MaxLength(450)]
        public string Password { get; set; }
        /// <summary>
        /// Historico de logins
        /// </summary>
        public virtual ICollection<LoginLog> LoginLogs { get; set; }

        /// <summary>
        /// Publicaciones del usuario
        /// </summary>
        public virtual ICollection<Post> Posts { get; set; }
    }
}
