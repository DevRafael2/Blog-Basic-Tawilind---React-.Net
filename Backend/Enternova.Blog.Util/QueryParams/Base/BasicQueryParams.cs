namespace Enternova.Blog.Util.QueryParams.Base
{
    public abstract class BasicQueryParams
    {
        /// <summary>
        /// Pagina actual
        /// </summary>
        public int ActualPage { get; set; } = 1;
        /// <summary>
        /// Elementos por pagina
        /// </summary>
        public int ElementsPerPage { get; set; } = 5;
    }
}
