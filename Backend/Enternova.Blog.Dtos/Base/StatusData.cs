namespace Enternova.Blog.Dtos.Base
{
    public class StatusData<Entity> : Status
    {
        /// <summary>
        /// Información que se devuelve con la respuesta/estado
        /// </summary>
        public Entity Data { get; set; }

        /// <summary>
        /// Cantidad de paginas que existen
        /// </summary>
        public int NumberOfPages { get; set; } = 0;
    }
}
