using Enternova.Blog.Models.Base;
using Enternova.Blog.Models.Entities.Security;

namespace Enternova.Blog.Models.Entities.Logs
{
    public class LoginLog : BaseModel<Guid>
    {
        /// <summary>
        /// Ip del dispositivo en donde se inicio sesión
        /// </summary>
        public string IpAdress { get; set; }
        /// <summary>
        /// Indica si el inicio de sesión fue exitoso
        /// </summary>
        public bool SignInSuccess { get; set; }
        /// <summary>
        /// Nombre del dispositivo en donde se inicio sesión
        /// </summary>
        public string DeviceName { get; set; }
        /// <summary>
        /// Sistema operativo del dispositivo donde se inició sesión
        /// </summary>
        public string OperatingSystem { get; set; }
        /// <summary>
        /// Id del usuario que logró/intentó iniciar sesión
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// Usuario que logró/intentó iniciar sesión
        /// </summary>
        public virtual User User { get; set; }
    }
}
