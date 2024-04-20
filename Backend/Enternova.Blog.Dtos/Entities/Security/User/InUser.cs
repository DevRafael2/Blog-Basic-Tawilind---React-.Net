using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enternova.Blog.Dtos.Entities.Security.User
{
    public class InUser
    {
        /// <summary>
        /// Nombre de usuario
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Primer nombre
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Primer apellido
        /// </summary>
        public string FirstLastName { get; set; }
        /// <summary>
        /// Contraseña del usuario en Sha256
        /// </summary>
        public string Password { get; set; }
    }
}
