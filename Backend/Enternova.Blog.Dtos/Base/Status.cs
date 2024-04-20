namespace Enternova.Blog.Dtos.Base
{
    public class Status
    {
        /// <summary>
        /// Indica si la tarea se completa con éxito
        /// </summary>
        public bool IsComplete { get; set; }
        /// <summary>
        /// Mensaje de entrega la Api
        /// </summary>
        public string Message { get; set; }
    }
}
