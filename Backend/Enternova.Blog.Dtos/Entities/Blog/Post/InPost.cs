using System.ComponentModel.DataAnnotations;

namespace Enternova.Blog.Dtos.Entities.Blog.Post
{
    public class InPost
    {
        /// <summary>
        /// Titulo de la publicación
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Descripcion/post de la publicación
        /// </summary>
        public string DescriptionPost { get; set; }
        /// <summary>
        /// Id del usuario que realiza la publicación/post
        /// </summary>
        public long UserId { get; set; }
    }
}
