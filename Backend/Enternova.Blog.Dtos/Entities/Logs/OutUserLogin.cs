namespace Enternova.Blog.Dtos.Entities.Logs
{
    public class OutUserLogin
    {
        /// <summary>
        /// Nombre de usuario/email
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Expiración
        /// </summary>
        public string Expire { get; set; }
        /// <summary>
        /// Nombre y apellido
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Id del usuario
        /// </summary>
        public long UserId { get; set; }

    }
}
