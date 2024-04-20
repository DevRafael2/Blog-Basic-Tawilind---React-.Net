using Enternova.Blog.Models.Entities.Blog;
using Enternova.Blog.Models.Entities.Security;
using Enternova.Blog.Util.QueryParams.Base;
using System.Linq.Expressions;

namespace Enternova.Blog.Util.QueryParams.Blog
{
    public class PostQueryParams : QueryParams<Post>
    {
        /// <summary>
        /// Id del usuario
        /// </summary>
        public long? UserId { get; set; } = null;
        /// <summary>
        /// Titulo de la publicacion
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Descripcion del post
        /// </summary>
        public string Description { get; set; }

        public override Expression<Func<Post, Post>> GetSelectExpression() => (e) => 
            new Post { Id = e.Id, Title = e.Title, DescriptionPost = e.DescriptionPost, UserId = e.UserId,
            CreatedAt = e.CreatedAt, UpdatedAt = e.UpdatedAt, User = new User { UserName = e.User.UserName } };

        public override Expression<Func<Post, bool>> GetWhereExpression() => 
            (e) => 
            (string.IsNullOrEmpty(Title) ? true : e.Title.Contains(Title)) && 
            (string.IsNullOrEmpty(Description) ? true : e.DescriptionPost.Contains(Description)) &&
            (UserId == null ? true : e.UserId == UserId);
    }
}
