namespace Enternova.Blog.Dtos.Entities.Logs
{
    public class InUserLogin
    {
        /// <summary>
        /// Nombre de usuario, en este caso email
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Contraseña
        /// </summary>
        public string Password { get; set; }



        /// <summary>
        /// Ip del origen / cliente
        /// </summary>
        public string OriginIp { get; set; }
        /// <summary>
        /// Nombre del dispositivo
        /// </summary>
        public string DeviceName { get; set; }
        /// <summary>
        /// Sistema operativo
        /// </summary>
        public string OperatingSystem { get; set; }
    }
}
