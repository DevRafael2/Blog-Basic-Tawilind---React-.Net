using Enternova.Blog.Models.Base;
using Enternova.Blog.Models.Entities.Security;
using System.ComponentModel.DataAnnotations;

namespace Enternova.Blog.Models.Entities.Blog
{
    public class Post : BaseModel<Guid>
    {
        /// <summary>
        /// Titulo de la publicación
        /// </summary>
        [MaxLength(50)]
        public string Title { get; set; }
        /// <summary>
        /// Descripcion/post de la publicación
        /// </summary>
        public string DescriptionPost { get; set; }
        /// <summary>
        /// Id del usuario que realiza la publicación/post
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// Usuario que realiza la publicación/post
        /// </summary>
        public virtual User User { get; set; }
    }
}
