using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enternova.Blog.Dtos.Entities.Security.User
{
    public class OutUser : InUser
    {
        /// <summary>
        /// Id del usuario
        /// </summary>
        public string Id { get; set; }
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
