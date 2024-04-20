using Enternova.Blog.Models.Base;

namespace Enternova.Blog.Models.Entities.Logs
{
    public class ErrorLog : BaseModel<Guid>
    {
        /// <summary>
        /// Origen de la excepcion
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// Mensaje de la excepción
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Excepcion interna
        /// </summary>
        public string InnerException { get; set; }
        /// <summary>
        /// Traza de la operacion
        /// </summary>
        public string Trace { get; set; }
        /// <summary>
        /// Metodo de destino
        /// </summary>
        public string TargetSite { get; set; }
    }
}
