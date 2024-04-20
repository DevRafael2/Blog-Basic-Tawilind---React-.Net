using Enternova.Blog.Models.Entities.Security;
using Enternova.Blog.Util.QueryParams.Base;
using System.Linq.Expressions;
namespace Enternova.Blog.Util.QueryParams.Security
{
    public class UserQueryParams : QueryParams<User>
    {

        /// <summary>
        /// Nombre de usuario
        /// </summary>
        public string UserName { get; set; }

        public override Expression<Func<User, User>> GetSelectExpression() => (e) => 
            new User { Id = e.Id, FirstName = e.FirstName, 
                FirstLastName = e.FirstLastName, Password = string.Empty, UserName = e.UserName, CreatedAt = e.CreatedAt, UpdatedAt = e.UpdatedAt};

        public override Expression<Func<User, bool>> GetWhereExpression() => 
            (d) => 
            (string.IsNullOrEmpty(UserName) ? true : d.UserName.Contains(UserName));
    }
}
